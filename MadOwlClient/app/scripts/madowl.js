
$.getJSON( "dummy.json", function( data ) {
  var items = [];
  $.each( data, function( key, val ) {
    items.push( "<span id='" + key + "'>" + val + "</span>" );
  });
 
  $( "<div />", {
    "class": "output",
    html: items.join( "" )
  }).appendTo( "body" );
});