﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public interface IAuthorRepository
    {
        List<Author> AllAuthors { get; }
    }
}