        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Amount: $(item).val(),
                    ID: $(item).data('id')
                    
                });
            });

            $.ajax({
                url: '/BakeryCart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Bakery/List";
                    }
                }
            })
        });