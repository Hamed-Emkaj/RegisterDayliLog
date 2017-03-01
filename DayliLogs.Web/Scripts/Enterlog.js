

  $(function () {
    $("#chkkari").click(function () {
      if ($(this).is(":checked")) {
        $("#trAz").show();
        $("#tt").show();
        $("#trTa").show();
        $("#lbl").show();
        $("#trrequester").show();
        $("#trMoType").show();
        $("#trFromDate").show();
        $("#chkghkari").hide();
        $("#chkma").hide();
        $("#chkmo").hide();
        $("#chkghkari1").hide();
        $("#chkma1").hide();
        $("#chkmo1").hide();
        $("#tronvan").show();
        $("#trtedad").show();
        $("#trtozihat").show();
        
       
      } else {
        $("#trrequester").hide();
        $("#trTa").hide();
        $("#lbl").hide();
        $("#tt").hide();
        $("#trAz").hide();
        $("#trMoType").hide();
        $("#trFromDate").hide();
        $("#chkghkari").show();
        $("#chkma").show();
        $("#chkmo").show();
        $("#chkghkari1").show();
        $("#chkma1").show();
        $("#chkmo1").show();
        $("#datepicker").val('');
        $("#trtozihat").hide();
        $("#trtozihat").val('');
        $("textarea").width(183);
        $("textarea").height(46);
        $("#tronvan").hide();
        $("#trtedad").hide();
        $("#trtozihat").hide();

    
        
      }
    });
  });



  $(function () {
    $("#chkghkari").click(function () {
      if ($(this).is(":checked")) {

        $("#trAz").show();
        $("#tt").show();
        $("#trTa").show();
        $("#trFromDate").show();
        $("#lbl").show();
        $("#submitButton").show();
        $("#trtozihat").show();
       
        $("#chkkari").hide();
        $("#chkma").hide();
        $("#chkmo").hide();
        $("#chkkari1").hide();
        $("#chkma1").hide();
        $("#chkmo1").hide();
      
      } else {
        $("#trTa").hide();
        $("#lbl").hide();
        $("#tt").hide();
        $("#trAz").hide();
        $("#trFromDate").hide();
        $("#submitButton").hide();
        $("#trtozihat").hide();
        $("#chkkari").show();
        $("#chkma").show();
        $("#chkmo").show();
        $("#chkkari1").show();
        $("#chkmo1").show();
        $("#chkma1").show();
        $("#trtozihat").val('');
        $("textarea").width(183);
        $( "textarea" ).height( 46 );
        $( "#trMoType" ).hide();

      }
    });
  });
  $(function () {
    $("#chkma").click(function () {
      if ($(this).is(":checked")) {
        $("#trAz").show();
        $("#tt").show();
        $("#trTa").show();
        $("#lbl").show();
        $("#trFromDate").show();
        $("#submitButton").show();
        $("#chkkari").hide();
        $("#chkghkari").hide();
        $("#trtozihat").show();
        $("#chkmo").hide();
        $("#chkkari1").hide();
        $("#chkghkari1").hide();
        $("#chkmo1").hide();
        $( "#submitButton" ).hide();
        $( "#trMoType" ).hide();
      } else {
         $("#trFromDate").hide();
        $("#trTa").hide();
        $("#trAz").hide();
        $("#tt").hide();
        $("#lbl").hide();
        $("#chkkari").show();
        $("#chkghkari").show();
        $("#chkmo").show();
        $("#chkkari1").show();
        $("#chkghkari1").show();
        $("#chkmo1").show();
        $("#chkghkari").show();
        $("#trtozihat").hide();
        $("#trtozihat").val('');
        $("textarea").width(183);
        $( "textarea" ).height( 46 );
        $( "#trMoType" ).hide();
      }
    });
  });



  $(function () {
    $("#chkmo").click(function () {
      if ($(this).is(":checked")) {
        $("#trAz").show();
        $("#tt").show();
        $("#trTa").show();
        $("#lbl").show();
        $("#trFromDate").show();
        $("#submitButton").show();
        $("#chkkari").hide();
        $("#chkghkari").hide();
        $("#trtozihat").show();
        $("#chkma").hide();
        $("#chkkari1").hide();
        $("#chkghkari1").hide();
        $( "#chkma1" ).hide();
        $( "#trMoType" ).hide();
      } else {
        $("#trFromDate").hide();
        $("#trTa").hide();
        $("#lbl").hide();
        $("#tt").hide();
        $("#trAz").hide();
        $("#chkkari").show();
        $("#chkghkari").show();
        $("#chkma").show();
        $("#chkkari1").show();
        $("#chkghkari1").show();
        $("#chkma1").show();
        $("#submitButton").hide();
        $("#trtozihat").hide();
        $("#trtozihat").val('');
        $("textarea").width(183);
        $( "textarea" ).height( 46 );
        $( "#trMoType" ).hide();
      }
    });
  });
  $("#submitButton").click(function () {
    if ($("#datepicker").val() == '') {
      $("#datealert").show();
  }
    });


  

 


