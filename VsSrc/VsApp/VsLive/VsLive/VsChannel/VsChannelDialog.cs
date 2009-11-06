// ghea	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// uhto	
// larn	 By downloading, copying, installing or using the software you agree to this license.
// ymop	 If you do not agree to this license, do not download, install,
// fchq	 copy or use the software.
// fjce	
// epii	                          License Agreement
// wope	         For OpenVss - Open Source Video Surveillance System
// rlqa	
// hkyj	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rxoa	
// aiee	Third party copyrights are property of their respective owners.
// tmtd	
// uzfx	Redistribution and use in source and binary forms, with or without modification,
// fave	are permitted provided that the following conditions are met:
// ylrx	
// kmwm	  * Redistribution's of source code must retain the above copyright notice,
// vohv	    this list of conditions and the following disclaimer.
// dxyh	
// ubdw	  * Redistribution's in binary form must reproduce the above copyright notice,
// leoj	    this list of conditions and the following disclaimer in the documentation
// umkr	    and/or other materials provided with the distribution.
// gsvh	
// pukg	  * Neither the name of the copyright holders nor the names of its contributors 
// gqpo	    may not be used to endorse or promote products derived from this software 
// lrie	    without specific prior written permission.
// fyzw	
// bycd	This software is provided by the copyright holders and contributors "as is" and
// wztu	any express or implied warranties, including, but not limited to, the implied
// widy	warranties of merchantability and fitness for a particular purpose are disclaimed.
// bfgd	In no event shall the Prince of Songkla University or contributors be liable 
// tzgj	for any direct, indirect, incidental, special, exemplary, or consequential damages
// mrbe	(including, but not limited to, procurement of substitute goods or services;
// lpkt	loss of use, data, or profits; or business interruption) however caused
// vkdv	and on any theory of liability, whether in contract, strict liability,
// noph	or tort (including negligence or otherwise) arising in any way out of
// qrlq	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	public class VsChannelDialog : VsPageWizard
	{
        private VsCoreServer vsCoreMonitor;
		private VsChannel vsChannel;
		private VsPageDescription vsChannelDescription = new VsPageDescription();
		private VsChannelStructure vsChannelStructure = new VsChannelStructure();
        private VsAnalyzerSettings vsAnalyzerSetting = new VsAnalyzerSettings();
        private VsEncoderSettings vsEncoderSetting = new VsEncoderSettings();

		// VsChannel property
		public VsChannel Channel
		{
			get { return vsChannel; }
		}

	    // Construction
		public VsChannelDialog(VsCoreServer vsCore)
		{
			this.AddPage(vsChannelDescription);
			this.AddPage(vsChannelStructure);
			this.Text = "Add Layout";

            vsCoreMonitor = vsCore;
            vsChannelDescription.CoreMonitor = vsCore;
            vsChannelStructure.CoreMonitor = vsCore;
            vsAnalyzerSetting.CoreMonitor = vsCore;
            vsEncoderSetting.CoreMonitor = vsCore;

            this.imagePanel.Visible = false;
		}

		// On page changing
		protected override void OnPageChanging(int page)
		{
            if (page == 1)
            {
                vsChannel = vsChannelDescription.Channel;
                vsChannelStructure.Channel = vsChannel;
                vsAnalyzerSetting.Channel = vsChannel;
                vsEncoderSetting.Channel = vsChannel;
            }
			base.OnPageChanging(page);
		}

        // On finish
        protected override void OnFinish()
        {
            vsAnalyzerSetting.FinalUpdate();
            vsEncoderSetting.FinalUpdate();

            // add camera to camera list
            vsCoreMonitor.AddChannel(vsChannel);
        }
	}
}

