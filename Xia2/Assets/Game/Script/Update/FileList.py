# -*- coding: utf-8 -*-
#cunkai
import os 
import shutil
import re
import csv
import platform
import sys

sysType = platform.system()
ESC = chr(27)
# 字体
a_default  = 0
a_bold     = 1
a_italic   = 3
a_underline= 4
# 前景颜色
fg_black   = 30
fg_red     = 31
fg_green   = 32
fg_yellow  = 33
fg_blue    = 34
fg_magenta = 35
fg_cyan    = 36
fg_white   = 37
# 后景颜色
bg_black   = 40
bg_red     = 41
bg_green   = 42
bg_yellow  = 43
bg_blue    = 44
bg_magenta = 45
bg_cyan    = 46
bg_white   = 47
 
def color_code(a):
    return ESC+"[%dm"%a
    
def color_str(s, *args):
    if(sysType =="Windows"):
        return s
    cs = ""
    for a in args:
        cs += color_code(a)
    cs += s
    cs += color_code(a_default)
    return cs 



print("\n\n\n\n\n\n\n\n\n")

path = os.path.split(os.path.realpath(__file__))[0]
filePath = path+"/../../../Resources/Json/"

fileList = path+"/fileList.json"

print(color_str("SYS: "+sysType,bg_blue, bg_cyan, a_bold))
print("coding: "+sys.getdefaultencoding())  

def toCsString(line):
    isItem = 0

    data = ''
    for i in range(len(line)):
        item = line[i]
        if item != '':
            isItem = 1
            data += '\"'+item+'\"'
            if i<len(line)-1:
                data += ','
        else:
        	data += '\"'+'-1'+'\"'
        	if i<len(line)-1:
        		data+=','

    if isItem==0:
        return ''
    return data

def openFile(name,ftype):
    fp=None

    if(sysType =="Windows"):
        try:
            fp=open(name,ftype,encoding='utf-8')
        except:  
            fp=open(name,ftype)
    else:
        fp=open(name,ftype)

    return fp

def start(rootDir): 
    print(rootDir)
    list_dirs = os.walk(rootDir)

    # remove old csharp
    #isExists=os.path.exists(csharp)
    #if isExists:
    #    shutil.rmtree(csharp)
    fp = openFile(fileList,'w')	
    fp.write("{ \n")
#    fp.close()

    for root, dirs, files in list_dirs: 
        for f in files: 
            filePath = os.path.join(root, f) 
            fname, fextension = os.path.splitext(f)
            #csharpFilePath = os.path.join(csharp, "data/"+"Static"+  fname[0:1].upper() + fname[1:]) + ".cs"
            # csharpFilePath = csharpFilePath.replace(csvPath,csharp)
			
            if fextension==".json":
				#print(color_str(" -- "+fname + " " + filePath,fg_cyan, bg_black, a_bold))
                subPath = filePath.split("Resources/")[1]
                print(color_str(" -- "+fname + " " + subPath,fg_cyan, bg_black, a_bold))
                fp.write("\t \"" + fname + "\" : \"" + subPath + "\" ,\n")			
           
#    fp = openFile(fileList,'w+')	
    fp.write("}\n")
    fp.close()
                
start(filePath)
print(color_str("GOOD",fg_white, bg_green, a_italic))
#coding=utf-8
if(sysType =="Windows"):
    raw_input(unicode('按回车键退出...','utf-8').encode('gbk'))
else:
    raw_input(unicode('按回车键退出...','utf-8').encode('utf-8'))
