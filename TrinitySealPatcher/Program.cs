﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dnlib;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace TrinitySealPatcher {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 1) {
                Console.WriteLine("TrinitySealPatcher.exe <infile>");
                return;
            }

            var runtimepath = Path.GetDirectoryName(typeof(Program).Assembly.Location) + "\\TrinitySeal.dll";
            var runtime = ModuleDefMD.Load(runtimepath);
            var target = ModuleDefMD.Load(args[0]);

            var folder = Path.GetDirectoryName(args[0]);

            var ctor = target.GlobalType.FindOrCreateStaticConstructor();

            ctor.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(new Importer(target).Import(runtime.Find("TrinitySeal.HashPatch", false).FindMethod("ApplyHook"))));

            var writer = new NativeModuleWriter(target, new NativeModuleWriterOptions(target, true));

            writer.Options.MetadataOptions.Flags |= MetadataFlags.PreserveAll | MetadataFlags.KeepOldMaxStack;

            writer.Options.MetadataOptions.PreserveHeapOrder(target, true);

            writer.Write(Path.Combine(folder, $"{Path.GetFileNameWithoutExtension(args[0])}-patched{Path.GetExtension(args[0])}"));

            var trintyDll = Path.Combine(folder, "TrinitySeal.dll");
            var trintyDllBak = Path.Combine(folder, "TrinitySeal.dll.bak");

            if (File.Exists(trintyDll)) {
                if (File.Exists(trintyDllBak))
                    File.Delete(trintyDllBak);

                File.Move(trintyDll, trintyDllBak);
            }

            File.Copy(runtimepath, trintyDll);
        }
    }
}