// Copyright (C) 2006-2007 MySQL AB
//
// This file is part of MySQL Tools for Visual Studio.
// MySQL Tools for Visual Studio is free software; you can redistribute it 
// and/or modify it under the terms of the GNU Lesser General Public 
// License version 2.1 as published by the Free Software Foundation
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA using System;

/*
 * This class contains implementation of the Field String attribute.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MySql.Data.VisualStudio.Descriptors
{
    /// <summary>
    /// This attribute is used to mark Database object attribute which contains 
    /// create fields.
    /// </summary>
    class OptionStringAttribute : Attribute
    {
    }
}
