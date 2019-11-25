using System;
using System.Collections.Generic;
using System.Text;

namespace TrinitySeal {
    public class Security {
        static Security() {
            ChallengesPassed = true;
        }

        public static void ChallengeCheck() {

        }

        public static bool ChallengesPassed;
    }
}
