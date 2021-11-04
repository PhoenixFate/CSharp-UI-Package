#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Text.Template
{
    public abstract class TemplateConfig
    {
        private readonly List<TemplateToken> _TokenList = new List<TemplateToken>();
        private Regex _Regex;

        public void AddToken(TemplateTokenType tokenType, string regex, bool stripEmptyLine)
        {
            AddToken(tokenType, regex, stripEmptyLine, null);
        }

        public void AddToken(TemplateTokenType tokenType, string regex, bool stripEmptyLine, string tokenId)
        {
            _TokenList.Add(new TemplateToken(regex, tokenType, stripEmptyLine, tokenId));
        }

        internal TokenMatch FindTokenMatch(Match match)
        {
            for (int i = 0; i < _TokenList.Count; i++)
            {
                if (match.Groups[i + 100].Success)
                {
                    return new TokenMatch(this.Regex, match, 
                        _TokenList[i].TokenType, 
                        _TokenList[i].RemoveEmptyLine, 
                        _TokenList[i].TokenId);
                }
            }

            return null;
        }

        internal Regex Regex
        {
            get
            {
                if (_Regex == null)
                {
                    StringBuilder regex = new StringBuilder();
                    for (int i = 0; i < _TokenList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(_TokenList[i].Regex))
                        {
                            if (regex.Length > 0)
                                regex.Append("|");
                            regex.AppendFormat("(?<{0}>{1})", i + 100, _TokenList[i].Regex);
                        }
                    }
                    _Regex = new Regex(regex.ToString(), RegexOptions.Singleline);
                }
                return _Regex;
            }
        }

        private struct TemplateToken
        {
            public readonly string Regex;
            public readonly TemplateTokenType TokenType;
            public readonly bool RemoveEmptyLine;
            public readonly string TokenId;

            public TemplateToken(string regex, TemplateTokenType tokenType, bool removeEmptyLine, string tokenId)
            {
                Regex = regex;
                TokenType = tokenType;
                RemoveEmptyLine = removeEmptyLine;
                TokenId = tokenId;
            }
        }
    }
}
