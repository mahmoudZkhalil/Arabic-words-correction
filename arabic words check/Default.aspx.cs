using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHunspell;

namespace arabic_words_check
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string queryText = QueryText.Text;

                bool correct = Global.SpellEngine["ar"].Spell(queryText);

                string result = "<br />";

                if (correct)
                {
                    result += "كلمة :" + Server.HtmlEncode(queryText) + " صحيحه.<br />";
                    ThesResult meanings = Global.SpellEngine["ar"].LookupSynonyms(queryText, true);
                    if (meanings != null)
                    {
                        foreach (ThesMeaning meaning in meanings.Meanings)
                        {
                            result += "<b>Meaning: " + Server.HtmlEncode(meaning.Description) + "</b><br />";
                            int number = 1;
                            foreach (string synonym in meaning.Synonyms)
                            {
                                result += number.ToString() + ": " + Server.HtmlEncode(synonym) + "<br />";
                                ++number;
                            }
                        }
                    }

                }
                else
                {
                    result += "كلمة :" + Server.HtmlEncode(queryText) + " غير صحيحه.<br /><br />اقتراحات:<br />";
                    List<string> suggestions = Global.SpellEngine["ar"].Suggest(queryText);
                    int number = 1;
                    foreach (string suggestion in suggestions)
                    {
                        result += number.ToString() + ": " + Server.HtmlEncode(suggestion) + "<br />";
                        ++number;
                    }
                }

                ResultHtml.Text = result;
            }
        }
    }
}