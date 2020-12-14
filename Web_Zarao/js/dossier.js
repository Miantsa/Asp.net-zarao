function GetDossier() {
    $.ajax({
        type: 'POST',
        url: "default.aspx/GetAutre",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) { 
            var dt=JSON.parse(data.d);
             var h={};
            var num=0;
              dt.forEach(autre=>{
                $("#liste-dossier").append(" <ul><li><input type='checkbox' class='filled-in red choix-autre' id='autre"+num+"' name='"+autre.Titre+"' /><label for='autre"+num+"'></label></li> <li><span><img src='IconAutre\\"+autre.Icon+"'/>"+autre.Titre+"</span></li><li > <div ><a href='Zarao_Dossier/Autres/"+autre.Titre+"' download> <i class='material-icons '>file_download</i></a><i class='material-icons DeleteAutre' name='"+autre.Titre+"'>delete</i> </div> </li><li><span>"+autre.Taille+"</span></li><li><span>"+autre.DateModif+"</span></li> </ul>");
                h[autre.Titre]=0;
                num++;
                console.log(autre.Icon);
            }); 
             $(".choix-autre").on("click",function(){
                if($(this).prop("checked")){
                    h[$(this).attr("name")]=1;
                }else{
                    h[$(this).attr("name")]=0;
                }
                var i=0;
                dt.forEach(item=>{
                    if(h[item.Titre]==1)
                        i++;
                });
                if(i>0){
                    $("#DownloadAutre").removeClass("disabled");
                   // $("#DeleteDocument").removeClass("disabled");
                }
                else{
                    $("#DownloadAutre").addClass("disabled");
                   // $("#DeleteDocument").addClass("disabled");
                }
                //alert($(this).attr("id"));  
            });
              $("#DownloadAutre").on("click",function(){
                var DownAll=$("#DownAllDossier")
                dt.forEach(element=>{
                    if(h[element.Titre]==1){
                        DownAll.attr("href","Zarao_Dossier/Autres/"+element.Titre);
                        DownAll.get(0).click();
                    }
                });
            });
             $(".DeleteAutre").on("click",function(){
                 var nom=$(this).attr("name");
                        $( "#dialogDossier1" ).dialog({
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
                                        url: "default.aspx/DeleteAutreSolo",
                                        data:"{'dossier':'"+nom+"'}",
                                        contentType: "application/json;charset=utf-8",
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.d);
                                            if(data.d)
                                                RefreshDossier();
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
                    $( "#dialogDossier1" ).dialog( "open" );
                    // event.preventDefault();
            });
             $("#UploadAutre").on("click",function(){
                 $("#inputAutre").get(0).click(); 
              });
                $("#inputAutre").change(function(){
            var files=$(this).get(0).files;   
           var formdata1 =new FormData(); 
                    formdata1.append('autre',files[0]);
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
                       RefreshDossier();
                        alert("Fichier uploadé");
                    }
                });  
                //alert("eeee");
            });
          },
    }); 
}
GetDossier();
function RefreshDossier(){
    $("#liste-dossier").text("");
    GetDossier();
}
$("#DownloadAutre").addClass("disabled");
$("#RefreshAutre").on("click",function(){
    RefreshDossier();
});