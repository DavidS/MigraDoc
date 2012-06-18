#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange (mailto:Stefan.Lange@pdfsharp.com)
//   Klaus Potzesny (mailto:Klaus.Potzesny@pdfsharp.com)
//   David Stephensen (mailto:David.Stephensen@pdfsharp.com)
//
// Copyright (c) 2001-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Diagnostics;
using System.Reflection;
using MigraDoc.DocumentObjectModel.Internals;
using MigraDoc.DocumentObjectModel.Visitors;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.IO;

namespace MigraDoc.DocumentObjectModel
{
  /// <summary>
  /// Represents the format of a text.
  /// </summary>
  public class FormattedText : DocumentObject, IVisitable
  {
    /// <summary>
    /// Initializes a new instance of the FormattedText class.
    /// </summary>
    public FormattedText()
    {
    }

    /// <summary>
    /// Initializes a new instance of the FormattedText class with the specified parent.
    /// </summary>
    internal FormattedText(DocumentObject parent) : base(parent) { }

    #region Methods
    /// <summary>
    /// Creates a deep copy of this object.
    /// </summary>
    public new FormattedText Clone()
    {
      return (FormattedText)DeepCopy();
    }

    /// <summary>
    /// Implements the deep copy of the object.
    /// </summary>
    protected override object DeepCopy()
    {
      FormattedText formattedText = (FormattedText)base.DeepCopy();
      if (formattedText.font != null)
      {
        formattedText.font = formattedText.font.Clone();
        formattedText.font.parent = formattedText;
      }
      if (formattedText.elements != null)
      {
        formattedText.elements = formattedText.elements.Clone();
        formattedText.elements.parent = formattedText;
      }
      return formattedText;
    }

    /// <summary>
    /// Adds a new Bookmark.
    /// </summary>
    public BookmarkField AddBookmark(string name)
    {
      return this.Elements.AddBookmark(name);
    }

    /// <summary>
    /// Adds a single character repeated the specified number of times to the formatted text.
    /// </summary>
    public Text AddChar(char ch, int count)
    {
      return this.Elements.AddChar(ch, count);
    }

    /// <summary>
    /// Adds a single character to the formatted text.
    /// </summary>
    public Text AddChar(char ch)
    {
      return this.Elements.AddChar(ch);
    }

    /// <summary>
    /// Adds a new PageField.
    /// </summary>
    public PageField AddPageField()
    {
      return this.Elements.AddPageField();
    }

    /// <summary>
    /// Adds a new PageRefField.
    /// </summary>
    public PageRefField AddPageRefField(string name)
    {
      return this.Elements.AddPageRefField(name);
    }

    /// <summary>
    /// Adds a new NumPagesField.
    /// </summary>
    public NumPagesField AddNumPagesField()
    {
      return this.Elements.AddNumPagesField();
    }

    /// <summary>
    /// Adds a new SectionField.
    /// </summary>
    public SectionField AddSectionField()
    {
      return this.Elements.AddSectionField();
    }

    /// <summary>
    /// Adds a new SectionPagesField.
    /// </summary>
    public SectionPagesField AddSectionPagesField()
    {
      return this.Elements.AddSectionPagesField();
    }

    /// <summary>
    /// Adds a new DateField.
    /// </summary>
    public DateField AddDateField()
    {
      return this.Elements.AddDateField();
    }

    /// <summary>
    /// Adds a new DateField.
    /// </summary>
    public DateField AddDateField(string format)
    {
      return this.Elements.AddDateField(format);
    }

    /// <summary>
    /// Adds a new InfoField.
    /// </summary>
    public InfoField AddInfoField(InfoFieldType iType)
    {
      return this.Elements.AddInfoField(iType);
    }

    /// <summary>
    /// Adds a new Footnote with the specified text.
    /// </summary>
    public Footnote AddFootnote(string text)
    {
      return this.Elements.AddFootnote(text);
    }

    /// <summary>
    /// Adds a new Footnote.
    /// </summary>
    public Footnote AddFootnote()
    {
      return this.Elements.AddFootnote();
    }

    /// <summary>
    /// Adds a text phrase to the formatted text.
    /// </summary>
    /// <param name="text">Content of the new text object.</param>
    /// <returns>Returns a new Text object.</returns>
    public Text AddText(string text)
    {
      return this.Elements.AddText(text);
    }

    /// <summary>
    /// Adds a new FormattedText.
    /// </summary>
    public FormattedText AddFormattedText()
    {
      return this.Elements.AddFormattedText();
    }

    /// <summary>
    /// Adds a new FormattedText object with the given format.
    /// </summary>
    public FormattedText AddFormattedText(TextFormat textFormat)
    {
      return this.Elements.AddFormattedText(textFormat);
    }

    /// <summary>
    /// Adds a new FormattedText with the given Font.
    /// </summary>
    public FormattedText AddFormattedText(Font font)
    {
      return this.Elements.AddFormattedText(font);
    }

    /// <summary>
    /// Adds a new FormattedText with the given text.
    /// </summary>
    public FormattedText AddFormattedText(string text)
    {
      return this.Elements.AddFormattedText(text);
    }

    /// <summary>
    /// Adds a new FormattedText object with the given text and format.
    /// </summary>
    public FormattedText AddFormattedText(string text, TextFormat textFormat)
    {
      return this.Elements.AddFormattedText(text, textFormat);
    }

    /// <summary>
    /// Adds a new FormattedText object with the given text and font.
    /// </summary>
    public FormattedText AddFormattedText(string text, Font font)
    {
      return this.Elements.AddFormattedText(text, font);
    }

    /// <summary>
    /// Adds a new FormattedText object with the given text and style.
    /// </summary>
    public FormattedText AddFormattedText(string text, string style)
    {
      return this.Elements.AddFormattedText(text, style);
    }

    /// <summary>
    /// Adds a new Hyperlink of Type "Local", 
    /// i.e. the target is a Bookmark within the Document
    /// </summary>
    public Hyperlink AddHyperlink(string name)
    {
      return this.Elements.AddHyperlink(name);
    }

    /// <summary>
    /// Adds a new Hyperlink
    /// </summary>
    public Hyperlink AddHyperlink(string name, HyperlinkType type)
    {
      return this.Elements.AddHyperlink(name, type);
    }

    /// <summary>
    /// Adds a new Image object
    /// </summary>
    public Image AddImage(string fileName)
    {
      return this.Elements.AddImage(fileName);
    }

    /// <summary>
    /// Adds a Symbol object.
    /// </summary>
    public Character AddCharacter(SymbolName symbolType)
    {
      return this.Elements.AddCharacter(symbolType);
    }

    /// <summary>
    /// Adds one or more Symbol objects.
    /// </summary>
    public Character AddCharacter(SymbolName symbolType, int count)
    {
      return this.Elements.AddCharacter(symbolType, count);
    }

    /// <summary>
    /// Adds a Symbol object defined by a character.
    /// </summary>
    public Character AddCharacter(char ch)
    {
      return this.Elements.AddCharacter(ch);
    }

    /// <summary>
    /// Adds one or more Symbol objects defined by a character.
    /// </summary>
    public Character AddCharacter(char ch, int count)
    {
      return this.Elements.AddCharacter(ch, count);
    }

    /// <summary>
    /// Adds one or more Symbol objects defined by a character.
    /// </summary>
    public Character AddSpace(int count)
    {
      return this.Elements.AddSpace(count);
    }

    /// <summary>
    /// Adds a horizontal tab.
    /// </summary>
    public void AddTab()
    {
      this.Elements.AddTab();
    }

    /// <summary>
    /// Adds a line break.
    /// </summary>
    public void AddLineBreak()
    {
      this.Elements.AddLineBreak();
    }

    /// <summary>
    /// Adds a new Bookmark
    /// </summary>
    public void Add(BookmarkField bookmark)
    {
      this.Elements.Add(bookmark);
    }

    /// <summary>
    /// Adds a new PageField
    /// </summary>
    public void Add(PageField pageField)
    {
      this.Elements.Add(pageField);
    }

    /// <summary>
    /// Adds a new PageRefField
    /// </summary>
    public void Add(PageRefField pageRefField)
    {
      this.Elements.Add(pageRefField);
    }

    /// <summary>
    /// Adds a new NumPagesField
    /// </summary>
    public void Add(NumPagesField numPagesField)
    {
      this.Elements.Add(numPagesField);
    }

    /// <summary>
    /// Adds a new SectionField
    /// </summary>
    public void Add(SectionField sectionField)
    {
      this.Elements.Add(sectionField);
    }

    /// <summary>
    /// Adds a new SectionPagesField
    /// </summary>
    public void Add(SectionPagesField sectionPagesField)
    {
      this.Elements.Add(sectionPagesField);
    }

    /// <summary>
    /// Adds a new DateField
    /// </summary>
    public void Add(DateField dateField)
    {
      this.Elements.Add(dateField);
    }

    /// <summary>
    /// Adds a new InfoField
    /// </summary>
    public void Add(InfoField infoField)
    {
      this.Elements.Add(infoField);
    }

    /// <summary>
    /// Adds a new Footnote
    /// </summary>
    public void Add(Footnote footnote)
    {
      this.Elements.Add(footnote);
    }

    /// <summary>
    /// Adds a new Text
    /// </summary>
    public void Add(Text text)
    {
      this.Elements.Add(text);
    }

    /// <summary>
    /// Adds a new FormattedText
    /// </summary>
    public void Add(FormattedText formattedText)
    {
      this.Elements.Add(formattedText);
    }

    /// <summary>
    /// Adds a new Hyperlink
    /// </summary>
    public void Add(Hyperlink hyperlink)
    {
      this.Elements.Add(hyperlink);
    }

    /// <summary>
    /// Adds a new Image
    /// </summary>
    public void Add(Image image)
    {
      this.Elements.Add(image);
    }

    /// <summary>
    /// Adds a new Character
    /// </summary>
    public void Add(Character character)
    {
      this.Elements.Add(character);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the font object.
    /// </summary>
    public Font Font
    {
      get
      {
        if (this.font == null)
          this.font = new Font(this);

        return this.font;
      }
      set
      {
        SetParent(value);
        this.font = value;
      }
    }
    [DV]
    internal Font font;

    /// <summary>
    /// Gets or sets the style name.
    /// </summary>
    public string Style
    {
      get { return this.style.Value; }
      set { this.style.Value = value; }
    }
    [DV]
    internal NString style = NString.NullValue;

    /// <summary>
    /// Gets or sets the name of the font.
    /// </summary>
    [DV]
    public string FontName
    {
      get { return Font.Name; }
      set { Font.Name = value; }
    }

    /// <summary>
    /// Gets or sets the name of the font.
    /// For internal use only.
    /// </summary>
    [DV]
    internal string Name
    {
      get { return Font.Name; }
      set { Font.Name = value; }
    }

    /// <summary>
    /// Gets or sets the size in point.
    /// </summary>
    [DV]
    public Unit Size
    {
      get { return Font.Size; }
      set { Font.Size = value; }
    }

    /// <summary>
    /// Gets or sets the bold property.
    /// </summary>
    [DV]
    public bool Bold
    {
      get { return Font.Bold; }
      set { Font.Bold = value; }
    }

    /// <summary>
    /// Gets or sets the italic property.
    /// </summary>
    [DV]
    public bool Italic
    {
      get { return Font.Italic; }
      set { Font.Italic = value; }
    }

    /// <summary>
    /// Gets or sets the underline property.
    /// </summary>
    [DV]
    public Underline Underline
    {
      get { return Font.Underline; }
      set { Font.Underline = value; }
    }

    /// <summary>
    /// Gets or sets the color property.
    /// </summary>
    [DV]
    public Color Color
    {
      get { return Font.Color; }
      set { Font.Color = value; }
    }

    /// <summary>
    /// Gets or sets the superscript property.
    /// </summary>
    [DV]
    public bool Superscript
    {
      get { return Font.Superscript; }
      set { Font.Superscript = value; }
    }

    /// <summary>
    /// Gets or sets the subscript property.
    /// </summary>
    [DV]
    public bool Subscript
    {
      get { return Font.Subscript; }
      set { Font.Subscript = value; }
    }

    /// <summary>
    /// Gets the collection of paragraph elements that defines the FormattedText.
    /// </summary>
    public ParagraphElements Elements
    {
      get
      {
        if (this.elements == null)
          this.elements = new ParagraphElements(this);

        return this.elements;
      }
      set
      {
        SetParent(value);
        this.elements = value;
      }
    }
    [DV(ItemType = typeof(DocumentObject))]
    internal ParagraphElements elements;
    #endregion

    #region Internal
    /// <summary>
    /// Converts FormattedText into DDL.
    /// </summary>
    internal override void Serialize(Serializer serializer)
    {
      bool isFormatted = false;
      if (!this.IsNull("Font"))
      {
        this.Font.Serialize(serializer);
        isFormatted = true;
      }
      else
      {
        if (!this.style.IsNull)
        {
          serializer.Write("\\font(\"" + this.Style + "\")");
          isFormatted = true;
        }
      }

      if (isFormatted)
        serializer.Write("{");

      if (!this.IsNull("Elements"))
        this.Elements.Serialize(serializer);

      if (isFormatted)
        serializer.Write("}");
    }

    /// <summary>
    /// Allows the visitor object to visit the document object and it's child objects.
    /// </summary>
    void IVisitable.AcceptVisitor(DocumentObjectVisitor visitor, bool visitChildren)
    {
      visitor.VisitFormattedText(this);

      if (visitChildren && this.elements != null)
        ((IVisitable)this.elements).AcceptVisitor(visitor, visitChildren);
    }

    /// <summary>
    /// Returns the meta object of this instance.
    /// </summary>
    internal override Meta Meta
    {
      get
      {
        if (meta == null)
          meta = new Meta(typeof(FormattedText));
        return meta;
      }
    }
    static Meta meta;
    #endregion
  }
}
