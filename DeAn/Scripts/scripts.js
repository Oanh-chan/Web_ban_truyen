//hiển thị hình
function ShowImagePreview(imadeUploader, previewImage)
{
    //nếu chọn 1 file 
    if (imadeUploader.files && imadeUploader.files[0])
    {
        //đọc file
        var reader = new FileReader();
        //load
        reader.onload = function (e)
        {
            //đưa hình vào thuộc tính đường dẫn src
            $(previewImage).attr('src', e.target.result);
        }
        //đọc đường dẫn dữ liệu
        reader.readAsDataURL(imadeUploader.files[0]);
    }
}