﻿using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Updated avalon editor with colorizing binding.
    /// </summary>
    public class MvvmTextEditor : TextEditor, INotifyPropertyChanged
    {
        #region Properties

        #region Dependency Properties

        /// <summary>
        /// Dependency property of text.
        /// </summary>
        public static DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor),
           new PropertyMetadata((obj, args) =>
           {
               MvvmTextEditor target = (MvvmTextEditor)obj;
           })
       );

        /// <summary>
        /// Property of text.
        /// </summary>
        public new string Text
        {
            get => base.Text; 
            set
            {
                base.Text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// Dependency property of colorizing.
        /// </summary>
        public static DependencyProperty ColorizingProperty =
            DependencyProperty.Register("Colorizing", typeof(DocumentColorizingTransformer), typeof(MvvmTextEditor),
            new PropertyMetadata((obj, args) =>
            {
                MvvmTextEditor target = (MvvmTextEditor)obj;
                DocumentColorizingTransformer tr = (DocumentColorizingTransformer)args.NewValue;
                IList<IVisualLineTransformer> transformers = target.TextArea.TextView.LineTransformers;
                transformers.ToList().RemoveAll(el => el.GetType() == typeof(DocumentColorizingTransformer));
                transformers.Add(tr);
            }));

        /// <summary>
        /// Property of colorizing.
        /// </summary>
        public DocumentColorizingTransformer Colorizing { get; set; }
        #endregion

        /// <summary>
        /// Text length.
        /// </summary>
        public int Length { get { return base.Text.Length; } }

        #endregion

        #region Events

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion

    }
}
