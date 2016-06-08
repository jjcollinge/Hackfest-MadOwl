
console.log("hwhoo hwhoo");

document.getElementById("btn-join").addEventListener("click", function(){
    $("#alerts").innerHTML ="";

    var pin = document.getElementById('pin').value;
    var username = document.getElementById('username').value;
    
    $.getJSON( "dummy.json", function( data ) {

        if(pin == data.PinCode){
            $('#notice-success').show();
            setTimeout(function() { 
                $('#notice-success').fadeOut(); 
            }, 5000);
            window.location.replace("userapp.html?pin="+encodeURIComponent(data.PinCode)+"&name="+encodeURIComponent(username)+"&hol="+encodeURIComponent(data.Name)+"&steps="+encodeURIComponent(data.StepCount));
        } else {
            $('#notice-fail').show();
            setTimeout(function() { 
                $('#notice-fail').fadeOut(); 
            }, 5000);
        }

    });

});

