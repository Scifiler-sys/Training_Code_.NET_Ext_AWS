import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prepend'
})
export class PrependPipe implements PipeTransform {

  //value variable references the left side of the pipe
  //The right side of the pipe will be the parameter that you will pass inside the pipe
  transform(value:string, prependValue: string): string {
    return prependValue + ": " +value;
  }

}
