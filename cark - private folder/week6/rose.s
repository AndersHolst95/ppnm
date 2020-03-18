.data
msg: .ascii "The answer is "
ans: .ascii "0\n"
end_msg: .byte 0
dice1: .byte 3
dice2: .byte 4
dice3: .byte 3
dice4: .byte 6
dice5: .byte 3
value: .byte 4

.text
.global _start  // _start is the default start position
                // the program always starts running
                // from _start.

dice_val:       // dice is on r1. 
                // returns petal value on r1
                // changes the flags
    tst %r1,#1      // is LSB of 'dice' 0?
    subnes %r1, #1   // sub one if odd
    moveq %r1,#0    // cond. mov if even
    bx %r14

_start:
    mov %r2, #0  // Zero r2
    mov %r3, #5   // number of dice

    ldr %r0,=dice1
loop:
    ldrb %r1,[%r0],#1 // load 'dice1', then increment r0
    bl dice_val     // puts val into r1
    add %r2, %r1    // add to r2
    subs %r3,#1
    bne loop


print:  /* Print.
            We assume r2 contains a single-digit number (between 0 and 9). 
            that we want to print. 
        
            We convert r2 into a string which in general is not easy.
            Here, we simply add r2 to char '0' */
    ldr %r0,=ans            // load '0'
    ldrb %r1,[%r0]
    add %r2,%r1             // add result to '0'
    strb %r2,[%r0]          // store back

/* print the message using print system call */
    mov %r0, #1 
    ldr %r1, =msg 
    ldr %r2,=end_msg-msg
    mov %r7, #4 
    swi #0 
    b exit

exit:
    /* Linux exit system call */
    mov %r0, #0 
    mov %r7, #1 
    swi #0   
