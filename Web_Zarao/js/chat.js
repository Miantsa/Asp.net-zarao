$("#btn-envoie").on("click",function(){
    var Msg=$("#message").val();
    if(Msg.length>0){
     SetMessage(Msg,$.cookie('pseudo'),$.cookie('avatar'));
    }
    else{
        alert("Message vide");
    }
  // GetMessage();
 
});

var i=0;
function GetMessage() {
    $.ajax({
        type: "POST",
        url: "default.aspx/GetMessage",
       // data:"{'msgInfo':'"+pseudo+"'}",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) {
        // $("#boite1").scrollTop(99999);
         var dt=JSON.parse(data.d);
         var n=dt.length;
         for(i;i<n;i++){
            if(i<n){
                 if(dt[i].Perso==$.cookie("pseudo")&&dt[i].Avatar==$.cookie("avatar")){
                    $("#boite-message").append(" <li class='boite-message'><img src='"+$.cookie('avatar')+"' alt='' class='circle moi'><span class='msg-moi'>"+dt[i].Msg+"</span></li>");
                 }else{
                    $("#boite-message").append("<li class='boite-message'><img src='"+dt[i].Avatar+"' alt='' class='circle autre'><span class='nom-autre'>"+dt[i].Perso+"</span><span class='msg-autre'>"+dt[i].Msg+"</span></li>");
                }  
            }if(i==n-1)
             $("#boite1").scrollTop(99999);
         }
        },
    });
}
function SetMessage(Msg,perso,avatar){
    var msgInfo={};
    msgInfo[0]=Msg;
    msgInfo[1]=perso;
    msgInfo[2]=avatar;
     $.ajax({
        type: "POST",
        url: "default.aspx/SetMessage",
        data:"{'msgInfo':'"+JSON.stringify(msgInfo)+"'}",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) {
           // $("#boite-message").append(" <li class='boite-message'><img src='"+$.cookie('avatar')+"' alt='' class='circle moi'><span class='msg-moi'>"+Msg+"</span></li>");
            //alert("Lasa le msg e");
            //$("#fin-lien").click();
          //  window.location="#fin";
          $("#boite1").scrollTop(99999);
               $("#message").val("");
        },
    });

}
var appelMessage=setInterval(GetMessage,1000);