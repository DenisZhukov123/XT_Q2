function CalcStr() 
{
    //var str = "3.5 +4*10-5.3 /5 ="
    var str = document.getElementById("text").value;
    var result = 0, matchArr = [], pattern = /\d+(\.\d+)?|[\+,\-,\*,\/,\=]{1}/ig;
    matchArr = str.match(pattern);
    if(matchArr[0]*1+"" !== "NaN")
        result += matchArr[0]*1;
    for(var i = 0; i < matchArr.length; i++) 
    {
        switch(matchArr[i])
        {
            case "+": 
            {
                result += matchArr[i+1] * 1;
            } break;
            case "-": 
            {
                result -= matchArr[i+1] * 1;
            } break;
            case "*":
            {
                result *= matchArr[i+1] * 1;
            } break;
            case "/":
            { 
                result /= matchArr[i+1] * 1;
            } break;
            case "=": break;
            default: continue; break;
        }
            /*for(var i = 0; i < matchArr.length; i++)
            document.write("result=",result,'<br>')*/   
    }
    document.write("<b>Заданное выражение:</b>" + '<br />' + str + '<br />');
    document.write("<b>Результат</b>:" + '<br />' + result.toFixed(2));
}