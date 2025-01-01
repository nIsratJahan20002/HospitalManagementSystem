DataLoad();

function DataLoad() {
    $.ajax({
        url: '/api/PatientInfo/GetAll',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var tr;
                for (var i = 0; i < data.length; i++) {
                    tr = $('<tr/>');
                    tr.append('<td><i onclick=DataBind(' + data[i].PatientId + ')><i class="fa fa-edit"></i></i></td>');
                    //tr.append('<td><i onclick=DataVoid(' + data[i].PatientId + ')><i class="fa fa-remove"></i></i></td>');
                    tr.append("<td>" + data[i].PatientId + "</td>");
                    tr.append("<td>" + data[i].PatientName + "</td>");
                    tr.append("<td>" + data[i].CellNo + "</td>");

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
        PatientName: $('#txtPatientName').val(),
        CellNo: $('#txtCellNo').val()
    }
    console.log(entity)
    $.ajax({

        url: '/api/PatientInfo/Save',
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
        url: '/api/PatientInfo/GetById/' + '?PatientId=' + row,
        type: 'Get',
        dataType: 'json',

        success: function (data, textStatus, xhr) {
            $('#txtPatientId').val(data[0].PatientId)
            $('#txtPatientName').val(data[0].PatientName)
            $('#txtCellNo').val(data[0].CellNo)
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function Update() {

    var entity = {
        PatientId: $('#txtPatientId').val(),
        PatientName: $('#txtPatientName').val(),
        PatientId: $('#txtCellNo').val()
    }
    $.ajax({
        url: '/api/PatientInfo/Update/',
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
        url: '/api/PatientInfo/InActive/' + '?PatientId=' + row,
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