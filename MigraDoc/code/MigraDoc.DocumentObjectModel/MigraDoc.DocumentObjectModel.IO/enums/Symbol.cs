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

namespace MigraDoc.DocumentObjectModel.IO
{
  /// <summary>
  /// The symbols used by DdlScanner/DdlParser.
  /// </summary>
  enum Symbol
  {
    // TokenType.None
    None,
    Eof,
    Eol,                    // End of line
    // TokenType.Keyword
    True,
    False,
    Null,

    // TokenType.Identifier
    Identifier,
    Comment,

    // TokenType.IntegerLiteral
    IntegerLiteral,
    HexIntegerLiteral,
    OctIntegerLiteral,

    // TokenType.StringLiteral
    StringLiteral,

    // TokenType.RealLiteral
    RealLiteral,

    // TokenType.OperatorOrPunctuator
    Slash,             // /
    BackSlash,         // \
    ParenLeft,         // (
    ParenRight,        // )
    BraceLeft,         // {
    BraceRight,        // }
    BracketLeft,       // [
    BracketRight,      // ]
    EmptyLine,         //CR LF CR LF
    Colon,             // :
    Semicolon,         // ;
    Assign,            // =
    Plus,              // +
    Minus,             // -
    Dot,               // .
    Comma,             // ,
    Percent,           // %
    Dollar,            // $
    Hash,              // #
    Currency,          // �
    //Questionmark,    // ?
    Quotationmark,     // "
    At,                // @
    //Bar,             // |
    PlusAssign,        // +=
    MinusAssign,       // -=
    CR,                // 0x0D
    LF,                // 0x0A

    // TokenType.Keyword
    Styles,
    Document,
    Section,
    TableTemplates,
    TableTemplate,
    Paragraph,
    HeaderOrFooter,   // Only used as context in ParseDocumentElements
    Header,
    PrimaryHeader,
    FirstPageHeader,
    EvenPageHeader,
    Footer,
    PrimaryFooter,
    FirstPageFooter,
    EvenPageFooter,
    Table,
    Columns,
    Column,
    Rows,
    Row,
    Cell,
    Image,
    TextFrame,
    Chart,
    Footnote,
    PageBreak,
    Barcode,

    // Diagramms
    HeaderArea,
    FooterArea,
    TopArea,
    BottomArea,
    LeftArea,
    RightArea,
    PlotArea,
    Legend,
    XAxis,
    YAxis,
    ZAxis,
    Series,
    XValues,
    Point,

    // paragraph formats
    Bold,
    Italic,
    Underline,
    FontSize,
    FontColor,
    Font,

    // Hyperlink used by ParagraphParser
    Hyperlink,

    // Token used by ParagraphParser
    Text,  // Plain text in a paragraph.
    Blank,
    Tab,
    NonBreakeableBlank,
    SoftHyphen,
    LineBreak,
    Space,
    NoSpace,

    // Field used by ParagraphParser
    Field,

    // Field types used by ParagraphParser
    DateField,
    PageField,
    NumPagesField,
    InfoField,
    SectionField,
    SectionPagesField,
    BookmarkField,
    PageRefField,

    Character, //???
    Symbol,
    Chr
  }
}
