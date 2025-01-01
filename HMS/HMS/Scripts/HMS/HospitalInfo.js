DataLoad();

function DataLoad() {
    $.ajax({
        url: '/api/HospitalInfo/GetAll',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var tr;
                for (var i = 0; i < data.length; i++) {
                    tr = $('<tr/>');
                    tr.append('<td><i onclick=DataBind(' + data[i].HospitalId + ')><i class="fa fa-edit"></i></i></td>');
                    tr.append('<td><i onclick=DataVoid(' + data[i].HospitalId + ')><i class="fa fa-remove"></i></i></td>');
                    tr.append("<td>" + data[i].HospitalId + "</td>");
                    tr.append("<td>" + data[i].HospitalName + "</td>");
                    tr.append("<td>" + data[i].Address + "</td>");

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
        HospitalName: $('#txtHospitalName').val(),
        Address: $('#txtAddress').val(),
    }
    console.log(entity)
    $.ajax({

        url: '/api/HospitalInfo/Save',
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