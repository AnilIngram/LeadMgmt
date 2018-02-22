function deleteLead(id) {
    var confirmation = confirm('Are you sure you want to delete?');
    if (confirmation) {   
                $.ajax({ 
                    url: 'http://localhost:7252/api/leads/' + id, 
                    type: 'DELETE', 
                    dataType: 'json', contentType: 'application/json',
                    data: { id: id },  
                    success: function () { 
                        location.reload();
                    }, 
                    error: function () { 
                        location.reload();
                    } 
                }); 
    }
}