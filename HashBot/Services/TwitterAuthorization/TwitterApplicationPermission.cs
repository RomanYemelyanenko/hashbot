using System;

namespace HashBot
{
	[Flags]
	public enum TwitterApplicationAccessLevel
	{
		Read = 1<<1,
		Write = 1<<2,
		ReadWrite = 1<<1 | 1<<2
	}
}

