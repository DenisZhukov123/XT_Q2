function TrimStr(str)
{  
    var separator = " \t,.:;"
    var temp=""
    var words=[]
    var index=0
    for(var i=0;i<str.length;i++)
    {
        if(separator.indexOf(str[i])==-1)
        {
            temp+=str[i]
            if(i==str.length-1)
                words[index]=temp
        }
        else
        {
            words[index]=temp
            index++
            temp=""
        }
    }
    return words
}
function CountChar(word,symbol)
{   
    var count=0
    for(var i=0;i<word.length;i++)
    {
        if(word[i].toUpperCase()==symbol.toUpperCase())
            count++
    }
    return count
}
function CharRemover()
{
    var countsym=[];
    var result="";
    var str=document.getElementById("text").value;
    var separator = " \t,.:;"
    var words=TrimStr(str)
    var repeat=false;
    for(var i=0;i<str.length;i++)
    {
        repeat=false;
        if(separator.indexOf(str[i])==-1&&typeof(countsym[str[i]]==undefined))
        {
            for(var j=0;j<words.length;j++)
            {
                if(CountChar(words[j],str[i])>=2)
                {
                    countsym[str[i]]=2;
                    repeat=true;
                    break;
                }
            }
            if(!repeat)
                result+=str[i];
        }
        else
            result+=str[i];
    }
    document.write("<b>Исходная строка:</b>" + '<br />' + str + '<br />');
    document.write("<b>Результат</b>:" + '<br />' + result);
}