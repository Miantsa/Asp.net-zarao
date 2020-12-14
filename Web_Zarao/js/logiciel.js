 function GetLogiciel(){
     $.ajax({
        type: 'POST',
        url: "default.aspx/GetLogiciel",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) { 
        var h={};
            var dt=JSON.parse(data.d);
            console.log(dt);
            dt.forEach(logiciel=>{
                $("#boite-logiciel").append("<div class='logiciel-div'><img src='IconLogiciel/"+logiciel.Icon+"' class='image' /> <span class='log-name'>"+logiciel.Nom+"</span><br /><span class='log-size'>"+logiciel.Taille+"</span><div class='choix' name='"+logiciel.Nom+"'><i class='material-icons '>check</i></div>  <div class='controle'><a href='Zarao_Dossier/Logiciels/"+logiciel.Nom+"' download> <i class='material-icons'>file_download</i></a><i class='material-icons DeleteLogiciel' name='"+logiciel.Nom+"'>delete</i></div></div>");
                h[logiciel.Nom]=0;
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
                dt.forEach(element=>{
                    if(h[element.Nom]==1)
                    i++;
                });
                console.log($(this).attr("name"));
                console.log(i+"//"+dt.Length);
                if(i>0){
                    $("#DownloadLogiciel").removeClass("disabled");
                }
                else{
                    $("#DownloadLogiciel").addClass("disabled");
                }
            });
            $("#UploadLogiciel").on("click",function(){
                $("#inputLogiciel").get(0).click(); 
            });
             $("#inputLogiciel").change(function(){
            var files=$(this).get(0).files;   
           var formdata =new FormData(); 
                    formdata.append('logiciel',files[0]);
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
                    RefreshLogiciel();
                    alert("Logiciel Uploadé");
                }
            });  
            });
             $("#DownloadLogiciel").on("click",function(e){
            var DownAll=$("#DownAllImage")
            data.d.forEach(element=>{
                if(h[element]==1){
                    DownAll.attr("href","Zarao_Dossier/Images/"+element);
                    DownAll.get(0).click();
                }
            });
            console.log("mdown");
        });
        $(".DeleteLogiciel").on("click",function(){
            var nom=$(this).attr("name");
                $( "#dialogLogiciel1" ).dialog({
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
                                url: "default.aspx/DeleteLogicielSolo",
                                data:"{'logiciel':'"+nom+"'}",
                                contentType: "application/json;charset=utf-8",
                                dataType: 'json',
                                success: function (data) {
                                    //alert(data.d);
                                    if(data.d)
                                        RefreshLogiciel();
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
            $( "#dialogLogiciel1" ).dialog( "open" );
            // event.preventDefault();
        });
        },
   });
 }
 GetLogiciel();
 $("#DownloadLogiciel").addClass("disabled");
 function RefreshLogiciel(){
    $("#boite-logiciel").text("");
    GetLogiciel();
 }
 $("#RefreshLogiciel").on("click",function(){
    RefreshLogiciel();
 });
 