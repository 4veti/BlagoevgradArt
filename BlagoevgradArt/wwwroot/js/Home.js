$(document).ready(() => {
    $.get('/api/statistics', data => {
        $('#countPaintings').text(data.paintingsCount);
        $('#countAuthors').text(data.authorsCount);
        $('#countGalleries').text(data.galleriesCount);
        $('#countExhibitions').text(data.exhibitionsCount);
    });
});