var variety = [];

//動物類別
variety[0] = ['狗','貓','其他（請在備註欄中說明）'];

//品種
variety["狗"] = ['米克斯','貴賓','米格魯','馬爾濟斯','哈士奇','博美','法國鬥牛犬','英國鬥牛犬','狐狸犬','吉娃娃','約克夏','臘腸','柴犬','狼犬','黃金獵犬','拉布拉多','西施','雪納瑞','比熊','巴哥','柯基','邊境牧羊犬','喜樂蒂','蝴蝶犬','西高地白梗','梗犬','波士頓梗犬','秋田','台灣犬','鬆獅犬','古代牧羊犬','傑克羅素','日本種','牛頭梗','英國查理士獵犬','高山犬','大丹狗','阿富汗','大麥町','獒犬','蘇俄牧羊犬','大白熊','拳師犬','獵狐梗','羅納威','巴吉度','杜賓','可卡','伯恩山','北京犬','喜馬拉雅','比特','惠比特犬','比利時馬利諾犬','美國鬥牛犬','拉薩','其他（請在備註欄中說明）'];

variety["貓"] = ['米克斯','金吉拉','俄羅斯藍貓','英國藍貓','緬因','豹貓','加菲貓','摺耳貓','暹羅貓','波斯','英國短毛貓','美國短毛貓','布偶貓','斯芬克斯貓','其他（請在備註欄中說明）'];


;(function($) {
    $.fn.animalVariety = function(settings) {
        var _defaultSettings = {};
        var _settings = $.extend(_defaultSettings, settings);
        var _handler = function() {


            // varietyCount - countryCount
            // animal - city
            // varieties - county 
            
            //init
            var container = this;
            var varietyCount = $(".varieties option", container).length;
            var animal = $(".animal", container);
            var varieties = $(".varieties", container);
            
            //event
            $.each(variety[0], function(value, key) {                 
                 animal
                     .append($("<option></option>")
                     .attr("value",value)
                     .text(key));
            });
                        
            // animal.change(function(){
            //     $(".varieties option:gt(" + varietyCount + ")", container).remove();
            //     $(".varieties option:eq(" + varietyCount + ")", container).remove();
                
            //     var selectIndex = $('option:selected', this).index();
            //     var selectText = $('option:selected', this).text();
                
            //     if(variety[selectText] != null){
            //         $.each(variety[selectText], function(key, value) {
            //              varieties
            //                  .append($("<option></option>")
            //                  .attr("value",value)
            //                  .text(key));
            //         });
            //     }
            //     variety.trigger('change');
            // });

            animal.change(function(){
                $(".varieties option:gt(" + varietyCount + ")", container).remove();
                $(".varieties option:eq(" + varietyCount + ")", container).remove();
                
                var selectIndex = $('option:selected', this).index();
                var selectText = $('option:selected', this).text();
                
                if(variety[selectText] != null){
                    $.each(variety[selectText], function(key, value) {
                         varieties
                             .append($("<option></option>")
                             .attr("value",value)
                             .text(value));
                    });
                }
                variety.trigger('change');
            });
            
            // county.change(function(){
            //     var animalSelectText = animal.children("option:selected").text();
            //     var varietiesSelectText = $("option:selected", this).text();
                
            //     if(variety[animalSelectText] != null && variety[animalSelectText][varietiesSelectText] != null)
            //         zipcode.val(zip[citySelectText][countySelectText]);
            //     else
            //         zipcode.val("");
            // });
            
            animal.trigger('change');
        };
        return this.each(_handler);
    };
})(jQuery);