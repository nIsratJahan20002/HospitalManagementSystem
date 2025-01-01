DataLoad();

function DataLoad() {
    $.ajax({
        url: '/api/DoctorInfo/GetAll',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var tr;
                for (var i = 0; i < data.length; i++) {
                    tr = $('<tr/>');
                    tr.append('<td><i onclick=DataBind(' + data[i].DoctorId + ')><i class="fa fa-edit"></i></i></td>');
                    //tr.append('<td><i onclick=DataVoid(' + data[i].DoctorId + ')><i class="fa fa-remove"></i></i></td>');
                    tr.append("<td>" + data[i].DoctorId + "</td>");
                    tr.append("<td>" + data[i].DoctorName + "</td>");

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

function Save() {

    var entity = {
        DoctorName: $('#txtDoctorName').val(),
    }
    console.log(entity)
    $.ajax({

        url: '/api/DoctorInfo/Save',
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
        url: '/api/DoctorInfo/GetById/' + '?DoctorId=' + row,
        type: 'Get',
        dataType: 'json',

        success: function (data, textStatus, xhr) {
            $('#txtDoctorId').val(data[0].DoctorId)
            $('#txtDoctorName').val(data[0].DoctorName)
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function Update() {

    var entity = {
        DoctorId: $('#txtDoctorId').val(),
        DoctorName: $('#txtDoctorName').val(),
    }
    $.ajax({
        url: '/api/DoctorInfo/Update/',
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
        url: '/api/DoctorInfo/InActive/' + '?DoctorId=' + row,
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