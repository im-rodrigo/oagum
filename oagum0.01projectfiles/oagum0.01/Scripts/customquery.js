$('#submit-button').click(function (e) {

    // ajax request
    $.ajax({
        async: true,
        cache: false,
        type: 'post',
        url: '/echo/html/',
        data: {
            html: '<p class="p-content">Search term: ' + $('#search-term').val() + '</p>'
        },
        dataType: 'html',
        success: function (data) {
            $('#results').append(data).show(function () {
                $('#limit').animate({
                    height: $("#results").height()
                }, 500);
            });
        }
    });
});