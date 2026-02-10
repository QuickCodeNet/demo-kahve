using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demo-kahve.ProductionModuleModule.Domain.Enums;

public enum ProcessStatus{
	[Description("Process is waiting to start")]
	Pending,
	[Description("Process is currently running")]
	InProgress,
	[Description("Process finished successfully")]
	Completed,
	[Description("Process encountered an error")]
	Failed
}
