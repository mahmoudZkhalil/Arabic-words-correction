using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NHunspell;

namespace arabic_words_check
{
    public class Global : System.Web.HttpApplication
    {
        static SpellEngine spellEngine;

        static public SpellEngine SpellEngine { get { return spellEngine; } }

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                string dictionaryPath = Hunspell.NativeDllPath;
                spellEngine = new SpellEngine();
                LanguageConfig enConfig = new LanguageConfig();
                enConfig.LanguageCode = "ar";
                enConfig.HunspellAffFile = Path.Combine(dictionaryPath, "ar.aff");
                enConfig.HunspellDictFile = Path.Combine(dictionaryPath, "ar.dic");
                enConfig.HunspellKey = "";
                enConfig.HyphenDictFile = Path.Combine(dictionaryPath, "hyph_en_us.dic");
                enConfig.MyThesDatFile = Path.Combine(dictionaryPath, "th_en_us_new.dat");
                spellEngine.AddLanguage(enConfig);
            }
            catch (Exception ex)
            {
                if (spellEngine != null)
                    spellEngine.Dispose();

                throw;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}