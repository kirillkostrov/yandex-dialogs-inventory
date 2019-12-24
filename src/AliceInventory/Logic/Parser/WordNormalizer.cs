﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP.Ner;
using EP.Ner.Core;
using EP.Morph;

namespace AliceInventory.Logic.Parser
{
    public static class WordNormalizer
    {
        public static string Normalize(string word)
        {
            if (word == null) return null;
            var newWord = "";
            ProcessorService.Initialize();
            var t1 = ProcessorService.IsInitialized;
            using (var proc = ProcessorService.CreateProcessor())
            {
                
                var valueParts = word.Trim().Split();
                var result = "";
                foreach (var valuePart in valueParts)
                {
                    var ar = proc.Process(new SourceOfAnalysis(valuePart));
                    for (var t = ar.FirstToken; t != null; t = t.Next)
                    {
                        var npt = NounPhraseHelper.TryParse(t, NounPhraseParseAttr.AdjectiveCanBeLast);
                        result += npt?.GetMorphVariant(MorphCase.Nominative, false).ToLower() ??
                                  t.GetNormalCaseText().ToLower();
                    }

                    result += " ";
                }

                newWord = result.Trim();
            }
            

            return newWord;

        }
    }
}
