function [out]=intrp100(in_vect)

len_x=length(in_vect);
x=1:len_x;
%newx=len_x/100:len_x/100:len_x;
newx=linspace(1, len_x);


out = interp1(x,in_vect,newx, 'cubic');
out=out';