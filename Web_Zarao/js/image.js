   //Appel liste Image
var imageClass;
var choixClass;
var controleClass;
function GetImage() {
$.ajax({
    type: "POST",
    url: "default.aspx/GetImageListe",
    contentType: "application/json;charset=utf-8",
    dataType: 'json',
    success: function (data) {
    var h={};
    $("#NumImage").text(data.d.length);
        data.d.forEach(element => {
            // alert(element);
            $("#boite-image").prepend("<div class='image-div'><img src='Zarao_Dossier/Images/"+element+ "' class='image'/><div class='choix' name='"+element+"'><i class='material-icons'>check</i></div> <div class='controle'><a id='test' href='Zarao_Dossier/Images/"+element+"' download> <i  class='material-icons'>file_download</i></a><i class='material-icons DeleteImageSolo'  name='"+element+"'>delete</i></div></div>");
            h[element]=0;

        });
        // $("#boite-image").prepend("<div class='image-div'><img src='Zarao_Dossier/Images/Desert.jpg' class='image' /><div class='choix'><i class='material-icons'>check</i></div> <div class='controle'> <i class='material-icons'>file_download</i><i class='material-icons'>delete</i></div></div>");
        $(".image").on("click", function () {
            var img = $(this).attr("src");
            $("#modal-image center img").attr("src", img);
            $("#modal-image").css("display", "block");   
        });
          
        $(".choix").on("click",function(){
            if(h[$(this).attr("name")]==1){
                $(this).css("background-color","rgba(0,0,0,0.2)");
                h[$(this).attr("name")]=0;
            }
            else if( h[$(this).attr("name")]==0){
                $(this).css("display","block");
                $(this).css("color","white");
                $(this).css("background-color","#2baf2b");
                h[$(this).attr("name")]=1;
            }
            var i=0;
            data.d.forEach(element=>{
                if(h[element]==1)
                i++;
            });
            console.log($(this).attr("name"));
            console.log(i+"//"+data.d.Length);
            if(i>0){
                $("#DownloadImage").removeClass("disabled");
                $("#DeleteImage").removeClass("disabled");
            }
            else{
                $("#DownloadImage").addClass("disabled");
                $("#DeleteImage").addClass("disabled");
            }
        });
        $("#DownloadLogiciel").on("click",function(e){
            var DownAll=$("#DownAllLogiciel")
            dt.forEach(element=>{
                if(h[element.Nom]==1){
                    DownAll.attr("href","Zarao_Dossier/Logiciels/"+element.Nom);
                    DownAll.get(0).click();
                }
            });
            console.log("mdown");
        });
        //Suppression Image
        $("#DeleteImage").on("click",function(){
        var liste={};
        var i=0;
                    data.d.forEach(element=>{
                if(h[element]==1){
                    liste[i]=element;
                    i++;
                }
            });
                    $( "#dialogImage1" ).dialog({
	            autoOpen: false,
	            width: 300,
	            buttons: [
		            {
			            text: "Ok",
			            click: function() {
				            $( this ).dialog( "close" );
                            //alert(liste[1]);
                                $.ajax({
                                type: "POST",
                                url: "default.aspx/DeleteImage",
                                data:"{'listeimage':'"+JSON.stringify(liste)+"'}",
                                contentType: "application/json;charset=utf-8",
                                dataType: 'json',
                                success: function (data) {
                                    //alert(data.d);
                                    if(data.d)
                                        RefreshImage();
                                },
                                });
			            }
		            },
		            {
			            text: "Cancel",
			            click: function() {
				            $( this ).dialog( "close" );
			            }
		            }
	            ]
            });
            $( "#dialogImage1" ).dialog( "open" );
        });
        //Suppression Image Solo
        $(".DeleteImageSolo").on("click",function(){
        var nom=$(this).attr("name");
                $( "#dialogImage1" ).dialog({
	            autoOpen: false,
	            width: 300,
	            buttons: [
		            {
			            text: "Ok",
			            click: function() {
				            $( this ).dialog( "close" );
                            //alert(liste[1]);
                                $.ajax({
                                type: "POST",
                                url: "default.aspx/DeleteImageSolo",
                                data:"{'image':'"+nom+"'}",
                                contentType: "application/json;charset=utf-8",
                                dataType: 'json',
                                success: function (data) {
                                    //alert(data.d);
                                    if(data.d)
                                        RefreshImage();
                                },
                                });
			            }
		            },
		            {
			            text: "Cancel",
			            click: function() {
				            $( this ).dialog( "close" );
			            }
		            }
	            ]
            });
            $( "#dialogImage1" ).dialog( "open" );
            // event.preventDefault();
        });
        $("#UploadImage").on("click",function(){
       
            $("#inputImage").get(0).click(); 
           
        });
         $("#inputImage").change(function(){
            var files=$(this).get(0).files;   
           var formdata =new FormData(); 
                    formdata.append('image',files[0]);
                //alert(files[0].name);
                  $("#progress").css("display","block");
                $("#progress #nomFichier").text(files[0].name);
                $.ajax({
                url: "default.aspx",
                type:"POST",
                processData:false,
                contentType:false,
                data:formdata,
                xhr:function(){
                        var xhr=new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress",function(evt){
                            if(evt.lengthComputable){
                                var percent=(evt.loaded/evt.total)*100;
                                console.log(percent);
                                $("#progress #pourcentage").text(percent.toFixed(1)+"%");
                            }
                        },false);
                        return xhr;
                    },
                success:function(result){
                    $("#progress").css("display","none");
                    RefreshImage();
                }
            });  
            });
            
        $("#modal-image").on("click", function () {
            $("#modal-image").css("display", "none");
                            
        });
    },
});
                
}
GetImage();
$("#RefreshImage").on("click",function(){
    RefreshImage();
});
function RefreshImage(){
    $("#image #boite-image").html("");
    GetImage();
}
$("#DownloadImage").addClass("disabled");
$("#DeleteImage").addClass("disabled");
/*  <div class="image-div">
            <img src="img/iron.jpg" class="image"  />
            <div class="choix"><i class="material-icons ">check</i></div> 
            <div class="controle"> 
                <i class="material-icons">file_download</i>
                <i class="material-icons">delete</i>
            </div>
        </div>*/