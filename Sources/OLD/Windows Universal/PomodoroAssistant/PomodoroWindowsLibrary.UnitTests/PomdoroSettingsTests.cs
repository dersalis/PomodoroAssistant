using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Atrx.Mobile.Windows.Pomodoro.Settings;

namespace PomodoroWindowsLibrary.UnitTests
{
    [TestClass]
    public class PomdoroSettingsTests
    {
        [TestMethod]
        public void PomodoroSettings_VariousValues_ReturnGoodIfValuesAreEqals()
        {
            int workDur = 25;
            int sBreakDur = 5;
            int lBreakDur = 15;
            int dTarget = 7;
            int pTolBreak = 4;
            bool isMute = true;
            bool isAutoCon = true;

            PomodoroSettings set = new PomodoroSettings(workDur, sBreakDur, lBreakDur, dTarget, pTolBreak, isMute, isAutoCon);

            Assert.AreEqual(set.WorkDuration, workDur);
            Assert.AreEqual(set.ShorBreakDuration, sBreakDur);
            Assert.AreEqual(set.LongBreakDuration, lBreakDur);
            Assert.AreEqual(set.DailyTarget, dTarget);
            Assert.AreEqual(set.PomodoroToLongBreak, pTolBreak);
            Assert.AreEqual(set.IsMuteSound, isMute);
            Assert.AreEqual(set.IsAutoContinue, isAutoCon);
        }
    }
}
