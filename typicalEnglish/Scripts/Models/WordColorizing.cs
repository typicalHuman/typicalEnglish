using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System.Windows;
using System.Windows.Media;

namespace typicalEnglish.Scripts.Models
{
    internal class WordColorizing : DocumentColorizingTransformer
    {
        #region Properties

        private string hlWord { get; set; }//highlight word

        #endregion

        #region Constructor

        public WordColorizing(string hlWord)
        {
            this.hlWord = hlWord.ToLower();
        }

        #endregion

        #region Methods
        protected override void ColorizeLine(DocumentLine line)
        {
            int lineStartOffset = line.Offset;
            string text = CurrentContext.Document.GetText(line).ToLower();
            int start = 0;
            int index;
            while ((index = text.IndexOf(hlWord, start)) >= 0)
            {
                base.ChangeLinePart(
                    lineStartOffset + index,
                    lineStartOffset + index + hlWord.Length,
                    (VisualLineElement element) => {
                        Typeface tf = element.TextRunProperties.Typeface;
                        element.TextRunProperties.SetTypeface(new Typeface(
                                new FontFamily("Candara"),
                                FontStyles.Normal,
                                FontWeights.Bold,
                                tf.Stretch
                            ));
                    });
                start = index + 1;
            }
        }
        #endregion
    }
}
