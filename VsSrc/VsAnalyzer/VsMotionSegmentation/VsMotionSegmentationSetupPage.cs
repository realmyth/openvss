// orcr	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// oqvg	
// ijhk	 By downloading, copying, installing or using the software you agree to this license.
// mrra	 If you do not agree to this license, do not download, install,
// bcun	 copy or use the software.
// mdtf	
// gygb	                          License Agreement
// ltsl	         For OpenVss - Open Source Video Surveillance System
// avjg	
// mzau	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// begf	
// mfdp	Third party copyrights are property of their respective owners.
// vfyr	
// qnel	Redistribution and use in source and binary forms, with or without modification,
// xxkq	are permitted provided that the following conditions are met:
// ktuo	
// qwjr	  * Redistribution's of source code must retain the above copyright notice,
// iknb	    this list of conditions and the following disclaimer.
// camh	
// wota	  * Redistribution's in binary form must reproduce the above copyright notice,
// uqgg	    this list of conditions and the following disclaimer in the documentation
// vbvm	    and/or other materials provided with the distribution.
// qyjp	
// pkjh	  * Neither the name of the copyright holders nor the names of its contributors 
// ksoq	    may not be used to endorse or promote products derived from this software 
// wmhk	    without specific prior written permission.
// swpp	
// bwoi	This software is provided by the copyright holders and contributors "as is" and
// ejwt	any express or implied warranties, including, but not limited to, the implied
// nnsp	warranties of merchantability and fitness for a particular purpose are disclaimed.
// awaj	In no event shall the Prince of Songkla University or contributors be liable 
// bxmr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// qexe	(including, but not limited to, procurement of substitute goods or services;
// adeh	loss of use, data, or profits; or business interruption) however caused
// jvoz	and on any theory of liability, whether in contract, strict liability,
// lglu	or tort (including negligence or otherwise) arising in any way out of
// jalf	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vs.Core.Analyzer;

namespace Vs.Analyzer.MotionSegmentation
{
    public partial class VsMotionSegmentationSetupPage : UserControl, VsICoreAnalyzerPage
    {
        private bool completed = false;
        public event EventHandler StateChanged;

        public VsMotionSegmentationSetupPage()
        {
            InitializeComponent();
        }

        #region VsICoreAnalyzerPage Members

        bool VsICoreAnalyzerPage.Apply()
        {
            return true;
        }

        bool VsICoreAnalyzerPage.Completed
        {
            get { return completed; }
        }

        void VsICoreAnalyzerPage.Display()
        {
            this.trackBar1.Focus();
        }

        VsICoreAnalyzerConfiguration VsICoreAnalyzerPage.GetConfiguration()
        {
            VsMotionSegmentationConfiguration cfg = new VsMotionSegmentationConfiguration();

            cfg.ThresholdAlpha = this.trackBar1.Value;
            cfg.ThresholdSigma = this.trackBar2.Value;

            return cfg;
        }

        void VsICoreAnalyzerPage.SetConfiguration(VsICoreAnalyzerConfiguration config)
        {
            VsMotionSegmentationConfiguration cfg = (VsMotionSegmentationConfiguration)config;

            if (cfg != null)
            {
                this.trackBar1.Value = cfg.ThresholdAlpha ;
                this.trackBar2.Value = cfg.ThresholdSigma;
            }
        }

       #endregion

        // Update state
        private void UpdateState()
        {
            completed = true;

            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
