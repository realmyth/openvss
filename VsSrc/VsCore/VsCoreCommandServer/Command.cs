// ntvf	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// frez	
// xvwa	 By downloading, copying, installing or using the software you agree to this license.
// vqrx	 If you do not agree to this license, do not download, install,
// qxjz	 copy or use the software.
// cevz	
// czjy	                          License Agreement
// fiae	         For OpenVss - Open Source Video Surveillance System
// ahup	
// anvi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// lugr	
// kwdr	Third party copyrights are property of their respective owners.
// tlkk	
// ftui	Redistribution and use in source and binary forms, with or without modification,
// yvcg	are permitted provided that the following conditions are met:
// igtp	
// uszn	  * Redistribution's of source code must retain the above copyright notice,
// wcxc	    this list of conditions and the following disclaimer.
// cboh	
// ydog	  * Redistribution's in binary form must reproduce the above copyright notice,
// vsft	    this list of conditions and the following disclaimer in the documentation
// ypyg	    and/or other materials provided with the distribution.
// nlre	
// loaf	  * Neither the name of the copyright holders nor the names of its contributors 
// arws	    may not be used to endorse or promote products derived from this software 
// wquq	    without specific prior written permission.
// ohhe	
// fmku	This software is provided by the copyright holders and contributors "as is" and
// gvkq	any express or implied warranties, including, but not limited to, the implied
// aare	warranties of merchantability and fitness for a particular purpose are disclaimed.
// tszk	In no event shall the Prince of Songkla University or contributors be liable 
// lsro	for any direct, indirect, incidental, special, exemplary, or consequential damages
// bigg	(including, but not limited to, procurement of substitute goods or services;
// gwjf	loss of use, data, or profits; or business interruption) however caused
// xoeq	and on any theory of liability, whether in contract, strict liability,
// iuba	or tort (including negligence or otherwise) arising in any way out of
// bwyp	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Vs.Core.Server.Command
{
    /// <summary>
    /// The command class.
    /// </summary>
    public class Command
    {
        private CommandType cmdType;
        /// <summary>
        /// The type of command to send.If you wanna use the Message command type,create a Message class instead of command.
        /// </summary>
        public CommandType CommandType
        {
            get { return cmdType; }
            set { cmdType = value; }
        }

        private IPAddress senderIP;
        /// <summary>
        /// [Gets/Sets] The IP address of command sender.
        /// </summary>
        public IPAddress SenderIP
        {
            get { return senderIP; }
            set { senderIP = value; }
        }

        private string senderName;
        /// <summary>
        /// [Gets/Sets] The name of command sender.
        /// </summary>
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

        private string commandBody;
        /// <summary>
        /// The body of the command.This string is different in various commands.
        /// </summary>
        public string MetaData
        {
            get { return commandBody; }
            set { commandBody = value; }
        }

        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="metaData"></param>
        public Command(CommandType type, string metaData)
        {
            this.cmdType = type;
            this.commandBody = metaData;
        }

        /// <summary>
        /// Creates an instance of command object to send over the network.
        /// </summary>
        public Command(CommandType type)
        {
            this.cmdType = type;
            this.commandBody = "";
        }
    }
}
