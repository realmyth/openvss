// wvkb	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// gdpz	
// zkba	 By downloading, copying, installing or using the software you agree to this license.
// wgio	 If you do not agree to this license, do not download, install,
// iayt	 copy or use the software.
// fymb	
// cxzb	                          License Agreement
// yark	         For OpenVss - Open Source Video Surveillance System
// buxg	
// hfct	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// rlak	
// oepl	Third party copyrights are property of their respective owners.
// nfjd	
// zeqy	Redistribution and use in source and binary forms, with or without modification,
// iizj	are permitted provided that the following conditions are met:
// doaz	
// tqyb	  * Redistribution's of source code must retain the above copyright notice,
// icgd	    this list of conditions and the following disclaimer.
// xecu	
// xcnx	  * Redistribution's in binary form must reproduce the above copyright notice,
// hoot	    this list of conditions and the following disclaimer in the documentation
// qolx	    and/or other materials provided with the distribution.
// eyxz	
// fsqd	  * Neither the name of the copyright holders nor the names of its contributors 
// larx	    may not be used to endorse or promote products derived from this software 
// fnck	    without specific prior written permission.
// ygfu	
// cwag	This software is provided by the copyright holders and contributors "as is" and
// ubbo	any express or implied warranties, including, but not limited to, the implied
// zhje	warranties of merchantability and fitness for a particular purpose are disclaimed.
// fbxj	In no event shall the Prince of Songkla University or contributors be liable 
// fgxf	for any direct, indirect, incidental, special, exemplary, or consequential damages
// nyix	(including, but not limited to, procurement of substitute goods or services;
// kpst	loss of use, data, or profits; or business interruption) however caused
// mduj	and on any theory of liability, whether in contract, strict liability,
// iquh	or tort (including negligence or otherwise) arising in any way out of
// yqed	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.Text;
using Vs.Playback.VsService;
using System.Globalization;
using NLog; 

namespace Vs.Playback
{
    class VsCoreEngine
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        private VsIDataConnect dataConn;
        private VsIPlayer player;

        public VsService.VsService service;

        public VsCoreEngine(VsIDataConnect dataConn, VsIPlayer player)
        {
            this.dataConn = dataConn;
            this.player = player;
        }

        public void connectData()
        {
            try
            {
             
                service = new VsService.VsService();    
      
              
                
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
        }

        public VsCamera[] getCamAll()
        {
            try
            {
                service.getCamAllAsync();
                return service.getCamAll();
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
            //try
            //{   
            //}
            //catch (Exception ex) 
            //{ System.Windows.Forms.MessageBox.Show("can't connect Web service :" + ex);
            //return new VsCamera[0];
            //}        
        }

        internal VsMotion[] getMotionOfCamAsPeriod(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                return service.getMotionOfCamAsPeriod(timeBegin, timeEnd, p);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        internal VsFileURL getFileUrlOfMotion(string p,DateTime motionDateTime)
        {
            try
            {
                return service.getFileUrlOfMotion(p, motionDateTime);
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return null;
        }

        internal List<int> getNumberOfMotionInDay(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                data.AddRange(service.getNumberOfMotionInDay(timeBegin, timeEnd, p));
                return data;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        internal List<int> getNumberOfMotionInMonth(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                data.AddRange(service.getNumberOfMotionInMonth(timeBegin, timeEnd, p));
                return data;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }

        internal List<int> getNumberOfMotionInYear(DateTime timeBegin, DateTime timeEnd, string p)
        {
            try
            {
                List<int> data = new List<int>();
                data.AddRange(service.getNumberOfMotionInYear(timeBegin, timeEnd, p));
                return data;
            }
            catch (Exception err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return null;
        }
    }
}
