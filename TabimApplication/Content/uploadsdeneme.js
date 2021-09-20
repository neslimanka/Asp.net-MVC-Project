


<script>
    function kontrol(input) {
        if (input.files && input.files[0]) {
            if (input.files[0].size > 1024 * 1000) {//boyut kontrolü
        alert("Boyut Büyük");
    document.getElementById("dosya").value = "";
}
            else {
                if (input.files[0].type != "image/jpeg") {//tür kontrolü
        alert("Format uygun değil");
    document.getElementById("dosya").value = "";
}
                else {
                    var resim = new FileReader();
                    resim.onload = function (e) {//resmin img taginde gösterilmesi
        $('#resmim')
            .attr('src', e.target.result);
    };
     resim.readAsDataURL(input.files[0]);
}
}
}
}
</script>