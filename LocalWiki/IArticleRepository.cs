﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public interface IArticleRepository
    {
        List<Article> AllArticles { get; }
    }
}
