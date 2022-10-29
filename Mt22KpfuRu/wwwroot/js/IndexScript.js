function UpdatePage(page) {
    $("#news").load(`/Home/Index?page=${page} #news-loaded`);
}