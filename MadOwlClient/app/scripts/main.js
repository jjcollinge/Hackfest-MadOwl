var dataurl = "dummy.json";
//var dataurl = "http://madowlkeyvault.westeurope.cloudapp.azure.com:8786/api/classroom?classname=classroom1"

console.log("hwhoo hwhoo");

document.getElementById("btn-join").addEventListener("click", function(){
    $("#alerts").innerHTML ="";

    var pin = document.getElementById('pin').value;
    var username = document.getElementById('username').value;
    
    $.getJSON( dataurl, function( data ) {
    
    console.log(data);

        if(pin == data.PinCode){
            $('#notice-success').show();
            setTimeout(function() { 
                $('#notice-success').fadeOut(); 
            }, 5000);
            window.location.replace("userapp.html?pin="+encodeURIComponent(data.Id)+"&name="+encodeURIComponent(username)+"&hol="+encodeURIComponent('Azure Hands-on-Lab')+"&steps="+encodeURIComponent(data.NumSteps));
        } else {
            $('#notice-fail').show();
            setTimeout(function() { 
                $('#notice-fail').fadeOut(); 
            }, 5000);
        }

    });

});

