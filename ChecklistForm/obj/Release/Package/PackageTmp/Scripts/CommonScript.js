
$(function () {
    //Initialize Select2 Elements
    $(".select2").select2();

    //Datemask dd/mm/yyyy
    $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    //Datemask2 mm/dd/yyyy
    $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
    $("#BinNumber").inputmask("A-A9-A*", { "placeholder": "L-LN-L-" });
    $("#BinNumberFrom").inputmask("999", { "placeholder": "NNN" });
    $("#BinNumberTo").inputmask("999", { "placeholder": "NNN" });
    //Money Euro
    $("[data-mask]").inputmask();

    //Date range picker
    //    $('#reservation').daterangepicker();
    // //   Date range picker with time picker
    //    $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
    ////    Date range as a button
    //    $('#daterange-btn').daterangepicker(
    //        {
    //            ranges: {
    //                'Today': [moment(), moment()],
    //                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
    //                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
    //                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
    //                'This Month': [moment().startOf('month'), moment().endOf('month')],
    //                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
    //            },
    //            startDate: moment().subtract(29, 'days'),
    //            endDate: moment()
    //        },
    //        function (start, end) {
    //            $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
    //        }
    //    );



    // iCheck for checkbox and radio inputs
    //   $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
    //       checkboxClass: 'icheckbox_minimal-blue',
    //       radioClass: 'iradio_minimal-blue'
    //   });
    // ///  Red color scheme for iCheck
    //   $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
    //       checkboxClass: 'icheckbox_minimal-red',
    //       radioClass: 'iradio_minimal-red'
    //   });
    // //  Flat red color scheme for iCheck
    //   $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
    //       checkboxClass: 'icheckbox_flat-green',
    //       radioClass: 'iradio_flat-green'
    //   });

    /////   Colorpicker
    //   $(".my-colorpicker1").colorpicker();
    // //  color picker with addon
    //   $(".my-colorpicker2").colorpicker();

    //   Timepicker
    //$(".timepicker").timepicker({
    //    showInputs: false
    //});
    //Data Table
    $("#example1").DataTable();
    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false
    });

    // Date picker
    $('#datepicker').datepicker({
        autoclose: true
    });
    $('#datepicker1').datepicker({
        autoclose: true
    });
});



$(function () {
    $(".close").click(function () {
        $("#myAlert").alert();
    });
});
function ddlProjectChanged() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetStationByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#StationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Station"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.StationId).text(this.StationName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}


function ddlStationChanged() {
    debugger;
    var StationId = $('#StationId').val();
    if (StationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetSubStationByStation",
            data: "{'StationId':'" + StationId + "'}",
            success: function (data) {
                var $dropdown = $("#SubStationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select SubStation"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.SubStationId).text(this.SubStationName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    } else {
        alert('Not Selected Station');
    }

}

function ddlSubStationChanged() {

    debugger;
    var SubStationId = $('#SubStationId').val();
    if (SubStationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetParametersBySubStation",
            data: "{'SubStationId':'" + SubStationId + "'}",
            success: function (data) {
                var $dropdown = $("#ParameterId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Parameter"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ParameterId).text(this.ParameterName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlParametersChanged() {
    var EducationId = $('#Educations_0__EducationId').val();
    if (EducationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Employee/GetCourseByEducation",
            data: "{'EducationId':'" + EducationId + "'}",
            success: function (data) {
                var $dropdown = $("#Courses_0__CourseId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Course"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.Id).text(this.Name));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlLimitsChanged() {
    var EducationId = $('#Educations_0__EducationId').val();
    if (EducationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Employee/GetCourseByEducation",
            data: "{'EducationId':'" + EducationId + "'}",
            success: function (data) {
                var $dropdown = $("#Courses_0__CourseId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Course"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.Id).text(this.Name));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectsChanged() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/IpqcFroms/GetMachineByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Machine"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.MachineName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectsChanged2() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetMachineByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Machine"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.MachineName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectsChanged5() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetMachineByProjectt",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Machine"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.MachineName));
                });
            },
            error: function () {
                alert('Get Locations Errorrrrr');
            }

        })
    }

}
function ddlProjectsChanged3() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/MaintenanceChecklsit/GetMachineByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Machine"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.MachineName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectsChanged4() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckPointChecklIst/GetMachineByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Machine"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.MachineName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlMachinesChanged() {
    var MachineId = $('#MachineId').val();
    if (MachineId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/IpqcFroms/GetCategoryByMachine",
            data: "{'MachineId':'" + MachineId + "'}",
            success: function (data) {
                var $dropdown = $("#CatId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Category"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.CatId).text(this.Category));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlCategoriesChanged() {
    var CatId = $('#CatId').val();
    if (CatId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/IpqcFroms/GetActivityByCategory",
            data: "{'CatId':'" + CatId + "'}",
            success: function (data) {
                var $dropdown = $("#ActivityId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Activity"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ActivityId).text(this.Activity));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}


function ddlStationsChanged() {
    var StationId = $('#StationId').val();
    if (StationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetInspectionByStation",
            data: "{'StationId':'" + StationId + "'}",
            success: function (data) {
                var $dropdown = $("#InspectId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Inspection"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.InspectId).text(this.Inspection));
                });
            },
            error: function () {
                alert('Get Locations ErrorI');
            }

        })
    }

}

function ddlInspectChanged() {
    var InspectId = $('#InspectId').val();
    if (InspectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetFrequencyByInspection",
            data: "{'InspectId':'" + InspectId + "'}",
            success: function (data) {
                var $dropdown = $("#FreqId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Inspection"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.FreqId).text(this.Frequency));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlFrequencyChanged() {
    var FreqId = $('#FreqId').val();
    if (FreqId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetPeriodByFrequency",
            data: "{'FreqId':'" + FreqId + "'}",
            success: function (data) {
                var $dropdown = $("#PeriodId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Inspection"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PeriodId).text(this.Periods));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlOperationsByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetOperationsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#OperationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Operation--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.OperationId).text(this.Operation));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlPartToInspectByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetPartToInspectByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#InspectId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Parts To Inspect--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.InspectId).text(this.parts));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlStationsSChanged() {
    var StationId = $('#StationId').val();
    if (StationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetCircuitInspectionItemByStation",
            data: "{'StationId':'" + StationId + "'}",
            success: function (data) {
                var $dropdown = $("#ItemId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select InspectionItem--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ItemId).text(this.InspectionItem));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlGetSectionByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetSectionByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#SectionId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Section--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.SectionId).text(this.Section));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlGetDestructiveInspectionByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetDestructiveInspectionByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#InspectionId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Inspection Items--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.InspectionId).text(this.Inspection));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlGetDestructiveWireByDestructiveInspection() {
    var InspectionId = $('#InspectionId').val();
    if (InspectionId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetDestructiveWireByDestructiveInspection",
            data: "{'InspectionId':'" + InspectionId + "'}",
            success: function (data) {
                var $dropdown = $("#WireId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Wires--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.WireId).text(this.Wire));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlGetPartNoByModel() {
    var ModelId = $('#ModelId').val();
    if (ModelId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetPartNoByModel",
            data: "{'ModelId':'" + ModelId + "'}",
            success: function (data) {
                var $dropdown = $("#PartId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select PartNo--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PartId).text(this.Part));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlModelNoByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetModelNoByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#ModelId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Model--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModelId).text(this.Model));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}



function ddlGetPartNoByModel2() {
    var ModelId = $('#ModelId').val();
    if (ModelId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckListCircuitRecord/GetPartNoByModel",
            data: "{'ModelId':'" + ModelId + "'}",
            success: function (data) {
                var $dropdown = $("#PartId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select PartNo--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PartId).text(this.Part));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlModelNoByProject2() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckListCircuitRecord/GetModelNoByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#ModelId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Model--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModelId).text(this.Model));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlAdhesiveByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetAdhesiveByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#AdhesiveId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Adhesive--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.AdhesiveId).text(this.Adhesive));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlTemparatureRangeByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetTemparatureRangeByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#TempId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Temperature Range--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.TempId).text(this.RangeName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlExponentsByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetExponentsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#ExpId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Exponents--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ExpId).text(this.Exponents));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlInspectorcategoryByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetInspectorcategoryByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#categoryId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Inspector Category--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.categoryId).text(this.category));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlInspectorsByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetInspectorsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#InspecId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Inspector Category--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.InspecId).text(this.Inspector));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlLocationByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetLocation",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#LocationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Location--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.LocationId).text(this.Locations));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}


function ddlPaperCollarByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetPaperCollarByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#CollarId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select PaperCollar--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.CollarId).text(this.Collar));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}


function ddlFacePlateC70ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetFacePlateC70ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#FacePlateId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select FacePlateC70--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.FacePlateId).text(this.FacePlate));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlFacePlateC91ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetFacePlateC91ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#FaceePlateId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select FacePlateC91--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.FaceePlateId).text(this.FacePlate));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlPlugShellC70ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetPlugShellC70ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#PlugId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select PlugShellC70--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PlugId).text(this.PlugShell));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlPlugShellC91ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetPlugShellC91ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#PlugShellId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select PlugShellC91--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PlugShellId).text(this.PlugShelll));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}


function ddlBootC70ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetBootC70ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#BootId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select BootC70--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.BootId).text(this.Boot));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlBootC91ByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetBootC91ByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#BoottId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select BootC91--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.BoottId).text(this.Boott));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlCableByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetCableByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#CableId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Cable--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.CableId).text(this.Cablee));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlSRByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetSRByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#SRId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Cable--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.SRId).text(this.SR));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlTearDropInspectionByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetTearDropInspection",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#TearId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Teardown Steps--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.TearId).text(this.TeardownSteps));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlZoneByBatch() {
    var BatchId = $('#BatchId').val();
    if (BatchId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetZoneByBatch",
            data: "{'BatchId':'" + BatchId + "'}",
            success: function (data) {
                var $dropdown = $("#ZoneId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Zone--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ZoneId).text(this.ZoneName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProductionLineLeaderByBatch() {
    var ZoneId = $('#ZoneId').val();
    if (ZoneId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetProductionLineLeaderByBatch",
            data: "{'ZoneId':'" + ZoneId + "'}",
            success: function (data) {
                var $dropdown = $("#ProdId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Production Line Leader--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ProdId).text(this.LineLeader));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProdModuleByProject() {
    var ZoneId = $('#ZoneId').val();
    if (ZoneId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetProdModuleByProject",
            data: "{'ZoneId':'" + ZoneId + "'}",
            success: function (data) {
                var $dropdown = $("#ModuleId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Station--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModuleId).text(this.Module));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlBatchByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetBatchByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#BatchId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Batch--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.BatchId).text(this.BatchName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlZoneByBatch2() {
    var BatchId = $('#BatchId').val();
    if (BatchId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetZoneByBatch",
            data: "{'BatchId':'" + BatchId + "'}",
            success: function (data) {
                var $dropdown = $("#ZoneId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Zone--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ZoneId).text(this.ZoneName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlZoneByBatchCheckList() {
    var BatchId = $('#BatchId').val();
    if (BatchId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetZoneByBatch",
            data: "{'BatchId':'" + BatchId + "'}",
            success: function (data) {
                var $dropdown = $("#ZoneId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Zone--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ZoneId).text(this.ZoneName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProdModuleByProjectCheckList() {
    var ZoneId = $('#ZoneId').val();
    if (ZoneId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetProdModuleByProject",
            data: "{'ZoneId':'" + ZoneId + "'}",
            success: function (data) {
                var $dropdown = $("#ModuleId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Station--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModuleId).text(this.Module));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlBatchByProjectCheckList() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetBatchByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#BatchId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Batch--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.BatchId).text(this.BatchName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlZoneByBatchReport() {
    var BatchId = $('#BatchId').val();
    if (BatchId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetZoneByBatch",
            data: "{'BatchId':'" + BatchId + "'}",
            success: function (data) {
                var $dropdown = $("#ZoneId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Zone--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ZoneId).text(this.ZoneName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProdModuleByProjectReport() {
    var ZoneId = $('#ZoneId').val();
    if (ZoneId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetProdModuleByProject",
            data: "{'ZoneId':'" + ZoneId + "'}",
            success: function (data) {
                var $dropdown = $("#ModuleId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Station--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModuleId).text(this.Module));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlBatchByProjectReport() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetBatchByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#BatchId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Batch--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.BatchId).text(this.BatchName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProductionLineLeaderByBatchReport() {
    var ZoneId = $('#ZoneId').val();
    if (ZoneId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetProductionLineLeaderByBatch",
            data: "{'ZoneId':'" + ZoneId + "'}",
            success: function (data) {
                var $dropdown = $("#ProdId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Production Line Leader--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ProdId).text(this.LineLeader));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlA246CMachinesByProject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetA246CMachinesByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#MachineId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Machine--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.MachineId).text(this.Machine));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlA246CCTPMCStationsByMachine() {
    var MachineId = $('#MachineId').val();
    if (MachineId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetA246CCTPMCStationsByMachine",
            data: "{'MachineId':'" + MachineId + "'}",
            success: function (data) {
                var $dropdown = $("#StationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Machine--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.StationId).text(this.Station));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlA246CStationCTPOneByMachine() {
    var MachineId = $('#MachineId').val();
    if (MachineId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetA246CCTPMCStationsByMachineLine2",
            data: "{'MachineId':'" + MachineId + "'}",
            success: function (data) {
                var $dropdown = $("#StationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Station--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.StationId).text(this.StationName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlA246CCTPMCParameterByStation() {
    var StationId = $('#StationId').val();
    if (StationId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/Get246CCTPMCParameterByStation",
            data: "{'StationId':'" + StationId + "'}",
            success: function (data) {
                var $dropdown = $("#ParameterId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--Select Parameter--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ParameterId).text(this.Parameter));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlGetPartNoByModelReport() {
    var ModelId = $('#ModelId').val();
    if (ModelId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetPartNoByModel",
            data: "{'ModelId':'" + ModelId + "'}",
            success: function (data) {
                var $dropdown = $("#PartId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select PartNo--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.PartId).text(this.Part));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlModelNoByProjectReport() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetModelNoByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#ModelId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Model--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ModelId).text(this.Model));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlVisualsByproject() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetA246CVisualsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#VisualsId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Inspection--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.VisualsId).text(this.Visual));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}
function ddlVisualsByprojectChecklist() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetA246CVisualsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#VisualsId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Inspection--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.VisualsId).text(this.Visual));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectChangedChecklist() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetStationByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#StationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Station"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.StationId).text(this.StationName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlVisualsByprojectReport() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetA246CVisualsByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#VisualsId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("--select Inspection--"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.VisualsId).text(this.Visual));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlProjectChangedReport() {
    var ProjectId = $('#ProjectId').val();
    if (ProjectId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Report/GetStationByProject",
            data: "{'ProjectId':'" + ProjectId + "'}",
            success: function (data) {
                var $dropdown = $("#StationId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Station"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.StationId).text(this.StationName));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlTotalDataChangedReport() {
    var MenuId = $('#MenuId').val();
    if (MenuId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Master/GetAllData",
            data: "{'MenuId':'" + MenuId + "'}",
            success: function (data) {
                var $dropdown = $("#SectionId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select Section With Inspection project"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.SectionId).text(this.InspectionProject + "Section-" + this.Section));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}

function ddlShiftLeaderByBatchReport() {
    var BatchId = $('#BatchId').val();
    if (BatchId != '') {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/CheckList/GetShiftLeaderByBatch",
            data: "{'BatchId':'" + BatchId + "'}",
            success: function (data) {
                var $dropdown = $("#ShiftLeaderId");
                $dropdown.empty();
                $dropdown.eq(0).append($("<option></option>").val("").text("Select ShiftLeader"));
                $.each(JSON.parse(data), function () {
                    $dropdown.append($("<option />").val(this.ShiftLeaderId).text(this.ShiftLeader ));
                });
            },
            error: function () {
                alert('Get Locations Error');
            }

        })
    }

}





