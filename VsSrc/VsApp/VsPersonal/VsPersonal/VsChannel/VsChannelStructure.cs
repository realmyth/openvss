// xzkw	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// miuw	
// wouy	 By downloading, copying, installing or using the software you agree to this license.
// etrs	 If you do not agree to this license, do not download, install,
// pcjb	 copy or use the software.
// lsio	
// jnou	                          License Agreement
// couv	         For OpenVss - Open Source Video Surveillance System
// svwv	
// svqe	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mryt	
// nptm	Third party copyrights are property of their respective owners.
// jfai	
// fnce	Redistribution and use in source and binary forms, with or without modification,
// qvny	are permitted provided that the following conditions are met:
// tzui	
// tygj	  * Redistribution's of source code must retain the above copyright notice,
// wwau	    this list of conditions and the following disclaimer.
// mfpt	
// uobt	  * Redistribution's in binary form must reproduce the above copyright notice,
// ublx	    this list of conditions and the following disclaimer in the documentation
// olqf	    and/or other materials provided with the distribution.
// ssex	
// hrkm	  * Neither the name of the copyright holders nor the names of its contributors 
// xqzo	    may not be used to endorse or promote products derived from this software 
// jjqn	    without specific prior written permission.
// efvz	
// xikb	This software is provided by the copyright holders and contributors "as is" and
// uuds	any express or implied warranties, including, but not limited to, the implied
// owuh	warranties of merchantability and fitness for a particular purpose are disclaimed.
// haqe	In no event shall the Prince of Songkla University or contributors be liable 
// rdnu	for any direct, indirect, incidental, special, exemplary, or consequential damages
// vdwd	(including, but not limited to, procurement of substitute goods or services;
// pmjk	loss of use, data, or profits; or business interruption) however caused
// lysi	and on any theory of liability, whether in contract, strict liability,
// prhk	or tort (including negligence or otherwise) arising in any way out of
// hcdm	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Vs.Core;
using Vs.Core.Server;

namespace Vs.Monitor
{
	/// <summary>
	/// Summary description for VsChannelStructure.
	/// </summary>
	public class VsChannelStructure : System.Windows.Forms.UserControl, VsIDialogWizard
	{
		private VsChannel vsChannel = null;
		private bool completed = true;

		private System.Windows.Forms.ImageList imageList;
        private VsChannelGrid vsChannelGrid;
        private System.ComponentModel.IContainer components;
        private Panel panel1;
        private TreeView camerasTree;

		// state changed event
		public event EventHandler StateChanged;
		// reset event
		public event EventHandler Reset;

        // CoreMonitor
        private VsCoreServer vsCoreMonitor;

        // Channel property
		public VsChannel Channel
		{
			get { return vsChannel; }
			set { vsChannel = value;}
		}

        // Core Monitor property
        public VsCoreServer CoreMonitor
        {
            set
            {
                // cache to current monitor
                vsCoreMonitor = value;

                // build lists
                BuildCameraTreeView();
            }
        }

        private void BuildCameraTreeView()
        {
            String[] cameraNames = vsCoreMonitor.ListCameras();
            foreach (String cn in cameraNames)
                camerasTree.Nodes.Add(cn);
        }

		// Constructor
		public VsChannelStructure()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		
            camerasTree.ItemDrag+=new ItemDragEventHandler(camerasTree_ItemDrag);
            vsChannelGrid.DragOver+=new DragEventHandler(vsChannelGrid_DragOver);
            vsChannelGrid.DragDrop+=new DragEventHandler(vsChannelGrid_DragDrop);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsChannelStructure));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.camerasTree = new System.Windows.Forms.TreeView();
            this.vsChannelGrid = new Vs.Monitor.VsChannelGrid();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.camerasTree);
            this.panel1.Location = new System.Drawing.Point(13, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 193);
            this.panel1.TabIndex = 3;
            // 
            // camerasTree
            // 
            this.camerasTree.AllowDrop = true;
            this.camerasTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camerasTree.Location = new System.Drawing.Point(0, 0);
            this.camerasTree.Name = "camerasTree";
            this.camerasTree.Size = new System.Drawing.Size(172, 193);
            this.camerasTree.TabIndex = 3;
            // 
            // vsChannelGrid
            // 
            this.vsChannelGrid.AllowDrop = true;
            this.vsChannelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vsChannelGrid.Cols = ((short)(2));
            this.vsChannelGrid.Location = new System.Drawing.Point(197, 10);
            this.vsChannelGrid.Name = "vsChannelGrid";
            this.vsChannelGrid.Rows = ((short)(2));
            this.vsChannelGrid.Size = new System.Drawing.Size(193, 193);
            this.vsChannelGrid.TabIndex = 1;
            // 
            // VsChannelStructure
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vsChannelGrid);
            this.Name = "VsChannelStructure";
            this.Size = new System.Drawing.Size(403, 213);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// PageName property
		public string PageName
		{
			get { return "Add Layout"; }
		}

		// PageDescription property
		public string PageDescription
		{
            get { return "Layouts structure"; }
		}

		// Completed property
		public bool Completed
		{
			get { return completed; }
		}

		// Show the page
		public void Display()
		{
			vsChannelGrid.Rows = vsChannel.Rows;
			vsChannelGrid.Cols = vsChannel.Cols;

			//UpdateGridLabels();
		}

		// Apply the page
		public bool Apply()
		{
            for (int j = 0; j < vsChannelGrid.Rows; j++)
            {
                for (int i = 0; i < vsChannelGrid.Cols; i++)
                {
                    String cameraName = vsChannelGrid.GetLabel(j, i);
                    if (cameraName != null)
                    {
                        VsCamera vsCamera = vsCoreMonitor.GetCameraByName(cameraName);
                        vsChannel.SetCamera(vsCamera.CameraID, vsCamera);
                    }
                }
            }
			return true;
		}

		// Update grid labels
		private void UpdateGridLabels()
		{
            String[] cameraNames = vsCoreMonitor.ListCameras();
            int count = 0;
            foreach (String cn in cameraNames)
            {
                int i = (count % vsChannelGrid.Cols);
                int j = (count - i) / vsChannelGrid.Rows;
                vsChannelGrid.SetLabel(cn, i, j);
                count++;
            }
		}

		// On dragging beggin
		private void camerasTree_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeNode dragNode = (TreeNode) e.Item;

			// drag it
            camerasTree.DoDragDrop(dragNode.FullPath, DragDropEffects.Copy);
		}

		// On dragging onject over vsChannel grid
        private void vsChannelGrid_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}

		// On dragging object dropperd
        private void vsChannelGrid_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string		name = (string) e.Data.GetData(typeof(string));
			string[]	nameParts = name.Split('\\');

			Point cpt = vsChannelGrid.PointToClient(new Point(e.X, e.Y));
			Point pt = vsChannelGrid.SetLabel(name, cpt);
		}
	}
}
