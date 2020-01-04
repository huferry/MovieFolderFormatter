using System;
using System.Linq;

namespace MovieFolderFormatter
{
    public class TitleNormalizer : ITitleNormalizer
    {
        private readonly ITitleProcessor[] titleProcessors;
        public TitleNormalizer(
            ITitleProcessor[] titleProcessors
        )
        {
            this.titleProcessors = titleProcessors;
        }

        public string Normalize(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidOperationException(
                    @"Unable to extract title."
                );
            }

            return titleProcessors.Aggregate(
                "", (result, processor) => processor.Process(result));
        }
    }

}