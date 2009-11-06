/*
 * DirectShow UUIDs (Universally Unique Identifiers)
 */

namespace Vs.Provider.Dshow.Core
{
	using System;
	using System.Runtime.InteropServices;

	/// <summary>
	/// DirectShow Classes IDs
	/// </summary>
	[ComVisible(false)]
	public class Clsid
	{
		// CLSID_SystemDeviceEnum
		public static readonly Guid SystemDeviceEnum =
			new Guid(0x62BE5D10, 0x60EB, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

		// CLSID_FilterGraph
		public static readonly Guid FilterGraph =
			new Guid(0xE436EBB3, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// CLSID_SampleGrabber
		public static readonly Guid SampleGrabber =
			new Guid(0xC1F400A0, 0x3F08, 0x11D3, 0x9F, 0x0B, 0x00, 0x60, 0x08, 0x03, 0x9E, 0x37);

		// CLSID_AsyncReader
		public static readonly Guid AsyncReader =
			new Guid(0xE436EBB5, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// 
		public static readonly Guid WindowsMediaSource =
			new Guid(0x6B6D0800, 0x9ADA, 0x11D0, 0xA5, 0x20, 0x00, 0xA0, 0xD1, 0x01, 0x29, 0xC0);
	}

	/// <summary>
	/// DirectShow Filter categories
	/// </summary>
	[ComVisible(false)]
	public class FilterCategory
	{
		// CLSID_AudioInputDeviceCategory
		public static readonly Guid AudioInputDevice =
			new Guid(0x33D9A762, 0x90C8, 0x11D0, 0xBD, 0x43, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

		// CLSID_VideoInputDeviceCategory
		public static readonly Guid VideoInputDevice =
			new Guid(0x860BB310, 0x5D01, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

		// CLSID_VideoCompressorCategory
		public static readonly Guid VideoCompressorCategory =
			new Guid(0x33D9A760, 0x90C8, 0x11D0, 0xBD, 0x43, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

		// CLSID_AudioCompressorCategory
		public static readonly Guid AudioCompressorCategory =
			new Guid(0x33D9A761, 0x90C8, 0x11D0, 0xBD, 0x43, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

		// CLSID_LegacyAmFilterCategory
		public static readonly Guid LegacyAmFilterCategory =
			new Guid(0x083863F1, 0x70DE, 0x11D0, 0xBD, 0x40, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);
	}


	/// <summary>
	/// DirectShow media types
	/// </summary>
	[ComVisible(false)]
	public class MediaType
	{
		// MEDIATYPE_Video
		public static readonly Guid Video =
			new Guid(0x73646976, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIATYPE_Interleaved
		public static readonly Guid Interleaved =
			new Guid(0x73766169, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIATYPE_Audio
		public static readonly Guid Audio =
			new Guid(0x73647561, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIATYPE_Text
		public static readonly Guid Text =
			new Guid(0x73747874, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIATYPE_Stream
		public static readonly Guid Stream =
			new Guid(0xE436EB83, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);
	}

	/// <summary>
	/// DirectShow media subtypes
	/// </summary>
	[ComVisible(false)]
	public class MediaSubType
	{
		// MEDIASUBTYPE_YUYV
		public static readonly Guid YUYV =
			new Guid(0x56595559, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIASUBTYPE_IYUV
		public static readonly Guid IYUV =
			new Guid(0x56555949, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIASUBTYPE_DVSD
		public static readonly Guid DVSD =
			new Guid(0x44535644, 0x0000, 0x0010, 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71);

		// MEDIASUBTYPE_RGB1
		public static readonly Guid RGB1 =
			new Guid(0xE436EB78, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB4
		public static readonly Guid RGB4 =
			new Guid(0xE436EB79, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB8
		public static readonly Guid RGB8 =
			new Guid(0xE436EB7A, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB565
		public static readonly Guid RGB565 =
			new Guid(0xE436EB7B, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB555
		public static readonly Guid RGB555 =
			new Guid(0xE436EB7C, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB24
		public static readonly Guid RGB24 =
			new Guid(0xE436Eb7D, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_RGB32
		public static readonly Guid RGB32 =
			new Guid(0xE436EB7E, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_Avi
		public static readonly Guid Avi =
			new Guid(0xE436EB88, 0x524F, 0x11CE, 0x9F, 0x53, 0x00, 0x20, 0xAF, 0x0B, 0xA7, 0x70);

		// MEDIASUBTYPE_Asf
		public static readonly Guid Asf =
			new Guid(0x3DB80F90, 0x9412, 0x11D1, 0xAD, 0xED, 0x00, 0x00, 0xF8, 0x75, 0x4B, 0x99);
	}
}
