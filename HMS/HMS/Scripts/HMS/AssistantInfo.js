DataLoad();

function DataLoad() {
    $.ajax({
        url: '/api/AssistantInfo/GetAll',
        type: 'Get',
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            if (data != null) {
                var tr;
                for (var i = 0; i < data.length; i++) {
                    tr = $('<tr/>');
                    tr.append('<td><i onclick=DataBind(' + data[i].AssistantId + ')><i class="fa fa-edit"></i></i></td>');
                    //tr.append('<td><i onclick=DataVoid(' + data[i].DoctorId + ')><i class="fa fa-remove"></i></i></td>');
                    tr.append("<td>" + data[i].AssistantId + "</td>");
                    tr.append("<td>" + data[i].AssistantName + "</td>");

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
        AssistantName: $('#txtAssistantName').val(),
    }
    console.log(entity)
    $.ajax({

        url: '/api/AssistantInfo/Save',
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
        url: '/api/AssistantInfo/GetById/' + '?AssistantId=' + row,
        type: 'Get',
        dataType: 'json',

        success: function (data, textStatus, xhr) {
            $('#txtAssistantId').val(data[0].AssistantId)
            $('#txtAssistantName').val(data[0].AssistantName)
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation')
        }
    });
}

function Update() {

    var entity = {
        AssistantId: $('#txtAssistantId').val(),
        AssistantName: $('#txtAssistantName').val(),
    }
    $.ajax({
        url: '/api/AssistantInfo/Update/',
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
        url: '/api/AssistantInfo/InActive/' + '?AssistantId=' + row,
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