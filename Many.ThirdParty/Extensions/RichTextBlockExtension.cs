using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.Extensions
{
    public class RichTextBlockExtension : DependencyObject
    {
        //public static string GetDocumentXaml(DependencyObject obj)
        //{
        //    return (string)obj.GetValue(DocumentXamlProperty);
        //}

        //public static void SetDocumentXaml(DependencyObject obj, string value)
        //{
        //    obj.SetValue(DocumentXamlProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for DocumentXaml.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DocumentXamlProperty =
        //    DependencyProperty.RegisterAttached("DocumentXaml", typeof(string), typeof(RickTextBoxExtension), new PropertyMetadata(0));




        //public static string GetDocumentXaml(DependencyObject obj)
        //{
        //    return (string)obj.GetValue(DocumentXamlProperty);
        //}
        //public static void SetDocumentXaml(DependencyObject obj, string value)
        //{
        //    obj.SetValue(DocumentXamlProperty, value);
        //}
        //public static readonly DependencyProperty DocumentXamlProperty =
        //  DependencyProperty.RegisterAttached(
        //    "DocumentXaml",
        //    typeof(string),
        //    typeof(RichTextBlockExtension),
        //    PropertyMetadata.Create(0, (obj, e) =>
        //   {
        //       var richTextBox = (RichTextBlock)obj;

        //        // Parse the XAML to a document (or use XamlReader.Parse())
        //        var xaml = GetDocumentXaml(richTextBox);
        //       var doc = new FlowDocument();
        //       var range = new TextRange(doc.ContentStart, doc.ContentEnd);

        //       range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
        //   DataFormats.Xaml);

        //        // Set the document
        //        richTextBox.Document = doc;

        //        // When the document changes update the source
        //        range.Changed += (obj2, e2) =>
        //       {
        //           if (richTextBox.Document == doc)
        //           {
        //               MemoryStream buffer = new MemoryStream();
        //               range.Save(buffer, DataFormats.Xaml);
        //               SetDocumentXaml(richTextBox,
        //           Encoding.UTF8.GetString(buffer.ToArray()));
        //           }
        //       };
        //   });

    }
}
