 /*<div class="video-div">
                    <div class="controle"> 
                        <i class="material-icons ">check</i>
                        <i class="material-icons">file_download</i>
                        <i class="material-icons">delete</i>
                    </div>
                    <video class="responsive-video"  controls>
                        <source src="img/naruto.mp4" type="video/mp4">
                    </video>
                </div>*/
function GetVideo() { 
    $.ajax({
        type: "POST",
        url: "default.aspx/GetVideoListe",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) {
            var h={};
            $("#NumVideo").text(data.d.length);
            data.d.forEach(element => {
                // alert(element);
                $("#boite-video").prepend("<div class='video-div'><div class='controle'> <i class='material-icons' name='"+element+"'>check</i><a href='Zarao_Dossier/Videos/"+element+"' download><i class='material-icons'>file_download</i></a><i class='material-icons DeleteVideoSolo' name='"+element+"'>delete</i></div><video class='responsive-video'  controls><source src='Zarao_Dossier/Videos/"+element+"' type='video/mp4' ></video></div>");
                h[element]=0;
                console.log(element);
                //type='video/mp4'
            });
            $("#video .controle i:nth-child(1) ").on("click",function(){
                if(h[$(this).attr("name")]==1){
                    $(this).css("color","white");
                    h[$(this).attr("name")]=0;
                }
                else if(h[$(this).attr("name")]==0){
                    $(this).css("color","#2baf2b");
                    h[$(this).attr("name")]=1;
                }
                var i=0;
                data.d.forEach(element=>{
                    if(h[element]==1)
                    i++;
                }); 
                if(i>0){
                    $("#DownloadVideo").removeClass("disabled");
                    $("#DeleteVideo").removeClass("disabled");
                }
                else{
                    $("#DownloadVideo").addClass("disabled");
                    $("#DeleteVideo").addClass("disabled");
                }
            });
            $("#DownloadVideo").on("click",function(){
                 var DownAll=$("#DownAllVideo")
                data.d.forEach(element=>{
                    if(h[element]==1){
                        DownAll.attr("href","Zarao_Dossier/Videos/"+element);
                        DownAll.get(0).click();
                    }
                });
            });
             //Suppression Image
        $("#DeleteVideo").on("click",function(){
        var liste={};
        var i=0;
            data.d.forEach(element=>{
                if(h[element]==1){
                    liste[i]=element;
                    i++;
                }
            });
                    $( "#dialogVideo1" ).dialog({
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
                                url: "default.aspx/DeleteVideo",
                                data:"{'listevideo':'"+JSON.stringify(liste)+"'}",
                                contentType: "application/json;charset=utf-8",
                                dataType: 'json',
                                success: function (data) {
                                    //alert(data.d);
                                    if(data.d)
                                        RefreshVideo();
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
            $( "#dialogVideo1" ).dialog( "open" );
        });
        //Suppression Image Solo
       $(".DeleteVideoSolo").on("click",function(){
        var nom=$(this).attr("name");
                $( "#dialogVideo1" ).dialog({
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
                                url: "default.aspx/DeleteVideoSolo",
                                data:"{'video':'"+nom+"'}",
                                contentType: "application/json;charset=utf-8",
                                dataType: 'json',
                                success: function (data) {
                                    //alert(data.d);
                                    if(data.d)
                                        RefreshVideo();
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
            $( "#dialogVideo1" ).dialog( "open" );
            // event.preventDefault();
        });
         $("#UploadVideo").on("click",function(){
            $("#inputVideo").get(0).click(); 
           
        });
         $("#inputVideo").change(function(){
            var files=$(this).get(0).files;   
           var formdata1 =new FormData(); 
                    formdata1.append('video',files[0]);
               // alert(files[0].name);
                $("#progress").css("display","block");
                $("#progress #nomFichier").text(files[0].name);
                $.ajax({
                    url: "default.aspx",
                    type:"POST",
                    data:formdata1,
                    processData:false,
                    contentType:false,   
                    enctype:'multipart/form-data',  
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
                    success:function(res){
                    $("#progress").css("display","none");
                       RefreshVideo();
                        alert("video uploadé");
                    }
                });  
                //alert("eeee");
            });
        },
    });
}
GetVideo();
$("#RefreshVideo").on("click",function(){
    RefreshVideo();
});
function RefreshVideo(){
    $("#boite-video").html("");
    GetVideo();
}
$("#DownloadVideo").addClass("disabled");
$("#DeleteVideo").addClass("disabled");