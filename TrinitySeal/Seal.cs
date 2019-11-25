using HarmonyLib;
using System;
using System.Windows.Forms;

namespace TrinitySeal {
    public class Seal {
        static Seal() {
            LoginPassed = false;
            InitPassed = false;
        }

        private static string Key { get; set; }
        private static string Salt { get; set; }
        public static string Secret { get; set; }
        private static string Message { get; set; }

        public static void UpdateDLL() {

        }

        public static void InitializeForm(string programid, string version, string variablekey, Form AuthForm, Form MainForm, SealColours Colour) {
           // new SealForm(programid, version, variablekey, AuthForm, MainForm, Colour).Show();
        }

        public static bool GrabVariables(string secretkey, string programtoken, string username, string password) {
            return true;
        }

        public static string Var(string Name) {
            return string.Empty;
        }

        public static bool Initialize(string version) {
            return true;
        }

        public static bool Login(string username, string password, bool message = true) {
            return true;
        }

        public static bool Register(string username, string password, string email, string token, bool message = true) {
            return true;
        }

        public static bool RedeemToken(string username, string password, string token, bool message = true) {
            return true;
        }

        public static bool LoginPassed = true;
        public static bool InitPassed = true;
    }
}
