using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace EmeraldProxyManager
{
    public static class XmlHelper
    {
        public static string FormatAsXML(string text)
        {
            string beforeXml = text.Substring(0, text.IndexOf("<"));
            string xml = text.Substring(text.IndexOf("<"));

            string Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            mStream.Close();
            writer.Close();

            return Result;
        }

        public static void HighlightRTF(RichTextBox rtb)
        {
            int k = 0;
            string str = rtb.Text;

            int st, en;
            int lasten = -1;
            while (k < str.Length)
            {
                st = str.IndexOf('<', k);

                if (st < 0)
                    break;

                if (lasten > 0)
                {
                    rtb.Select(lasten + 1, st - lasten - 1);
                    rtb.SelectionColor = HighlightColors.HC_INNERTEXT;
                }

                en = str.IndexOf('>', st + 1);
                if (en < 0)
                    break;

                k = en + 1;
                lasten = en;

                if (str[st + 1] == '!')
                {
                    rtb.Select(st + 1, en - st - 1);
                    rtb.SelectionColor = HighlightColors.HC_COMMENT;
                    continue;

                }
                String nodeText = str.Substring(st + 1, en - st - 1);

                bool inString = false;

                int lastSt = -1;
                int state = 0;
                /* 0 = before node name
                 * 1 = in node name
                   2 = after node name
                   3 = in attribute
                   4 = in string
                   */
                int startNodeName = 0, startAtt = 0;
                for (int i = 0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"')
                        inString = !inString;

                    if (inString && nodeText[i] == '"')
                        lastSt = i;
                    else if (nodeText[i] == '"')
                    {
                        rtb.Select(lastSt + st + 2, i - lastSt - 1);
                        rtb.SelectionColor = HighlightColors.HC_STRING;
                    }

                    switch (state)
                    {
                        case 0:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startNodeName = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (Char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodeName + st, i - startNodeName + 1);
                                rtb.SelectionColor = HighlightColors.HC_NODE;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startAtt = i;
                                state = 3;
                            }
                            break;

                        case 3:
                            if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAtt + st, i - startAtt + 1);
                                rtb.SelectionColor = HighlightColors.HC_ATTRIBUTE;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                                state = 2;
                            break;
                    }

                }
                if (state == 1)
                {
                    rtb.Select(st + 1, nodeText.Length);
                    rtb.SelectionColor = HighlightColors.HC_NODE;
                }
            }
        }

        public static string DeleteFirstLineIfNeeded(string str)
        {
            if (!str.StartsWith("<?xml"))
                return str;
            int n = 1;
            string[] lines = str
                .Split(Environment.NewLine.ToCharArray())
                .Skip(n)
                .ToArray();

            return string.Join(Environment.NewLine, lines.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
