HospitalsLoad();
DoctorsLoad(); DataLoad();

function DataLoad() {
    $.ajax({
        url: '/api/ScheduleCreate/GetAll',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var tr;
                for (var i = 0; i < data.length; i++) {
                    tr = $('<tr/>');
                    tr.append("<td>" + data[i].ScheduleId + "</td>");
                    tr.append("<td>" + data[i].HospitalName + "</td>");
                    tr.append("<td>" + data[i].DoctorName + "</td>");
                    tr.append("<td>" + data[i].ScheduleDateTime + "</td>");
                    tr.append("<td>" + data[i].Active + "</td>");

                    $('#tblInfo').append(tr);
                }
            }
            else {
                alert("Error")
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function HospitalsLoad() {
    $.ajax({
        url: '/api/ScheduleCreate/GetHospitals',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var ddl = $('#ddlHospitals');
                ddl.empty();
                $.each(data, function (key, entry) {
                    console.log(entry)
                    ddl.append($('<option></option>').attr('value', entry.HospitalId).text(entry.HospitalName));
                });
            }
            else {
                alert("Error")
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function DoctorsLoad() {
    $.ajax({
        url: '/api/ScheduleCreate/GetDoctors',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var ddl = $('#ddlDoctors');
                ddl.empty();
                $.each(data, function (key, entry) {
                    ddl.append($('<option></option>').attr('value', entry.DoctorId).text(entry.DoctorName));
                });
            }
            else {
                alert("Error")
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function Save() {

    var entity = {
        HospitalId: $('#ddlHospitals').val(),
        DoctorId: $('#ddlDoctors').val(),
        Active: $('#ddlActiveInactive').val(),
    }
    console.log(entity)
    $.ajax({

        url: '/api/ScheduleCreate/Save',
        type: 'POST',
        datatype: 'json',
        data: entity,
        success: function (data, textStatus, xhr) {
            if (data != null) {
                alert('Saved Successfuly')
                location.reload();
            }
            else {
                alert('Error')
            }
        },
        error: function (xhr, textStatus, errorthrown) {
            console.log('Error in operation')
        }

    });
}

function DataBind(row) {
    $.ajax({
        url: '/api/HospitalInfo/GetById/' + '?HospitalId=' + row,
        type: 'Get',
        dataType: 'json',

        success: function (data, textStatus, xhr) {
            $('#txtHospitalId').val(data[0].HospitalId)
            $('#txtHospitalName').val(data[0].HospitalName)
            $('#txtAddress').val(data[0].Address)
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function Update() {

    var entity = {
        HospitalId: $('#txtHospitalId').val(),
        HospitalName: $('#txtHospitalName').val(),
        Address: $('#txtAddress').val(),
    }
    $.ajax({
        url: '/api/HospitalInfo/Update/',
        type: 'POST',
        dataType: 'json',
        data: entity,
        success: function (data, textStatus, xhr) {
            if (data == 1) {
                alert("Update Succesfully")
                location.reload();
            }
            else {
                alert("Please, Select data")
            }

        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function DataVoid(row) {
    $.ajax({
        url: '/api/HospitalInfo/InActive/' + '?HospitalId=' + row,
        type: 'POST',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                alert("In-active Succesfully")
                location.reload();
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}