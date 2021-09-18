var hasUploadedOne = false;// 已上傳過1張圖片
var hasUploadedTwo = false;// 已上傳過2張圖片

//獲取到預覽框
var imgObjPreview1 = document.getElementById("look1");
var imgObjPreview2 = document.getElementById("look2");
var imgObjPreview3 = document.getElementById("look3");

document.getElementById('file').onchange = function() {
    // 若還沒完成2張圖片的上傳
    if(!hasUploadedTwo){
        //獲取到file的檔案
        var docObj = this;

        //獲取到檔名和型別（非IE，可一次上傳1張或多張）
        if(docObj.files && docObj.files[0]) {
            // 一次上傳了>=2張圖片（只有前兩張會真的上傳上去）
            if(docObj.files.length >= 2){
                imgObjPreview1.src = window.URL.createObjectURL(docObj.files[0]);
                imgObjPreview2.src = window.URL.createObjectURL(docObj.files[1]);
                imgObjPreview3.src = window.URL.createObjectURL(docObj.files[2]);
                hasUploadedTwo = true;
            }
            //一次只上傳了1張照片
            else{
                // 這是上傳的第一張照片
                if(!hasUploadedOne){
                    imgObjPreview1.src = window.URL.createObjectURL(docObj.files[0]);
                    hasUploadedOne = true;
                }
                // 這是上傳的第二張照片
                else{
                    imgObjPreview2.src = window.URL.createObjectURL(docObj.files[0]);
                    hasUploadedTwo = true;
                }
            }

        }
        //IE（只能一次上傳1張）
        else {
            //使用濾鏡
            docObj.select();
            var imgSrc = document.selection.createRange().text;
            // 這是上傳的第一張照片
            if(!hasUploadedOne){
                imgObjPreview1.src = imgSrc;
                hasUploadedOne = true;
            }
            // 這是上傳的第二張照片
            else{
                imgObjPreview2.src = imgSrc;
                hasUploadedTwo = true;
            }
            document.selection.empty();
        }
        return true;
    }
}