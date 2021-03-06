using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranSmart.Static
{
    public class MailBody
    {
        #region Template1
        public static string Template1 = @"
             <div><div autoid='_rp_F' class='_rp_q5 rpHighlightAllClass rpHighlightBodyClass allowTextSelection' role='region' aria-label='Message body'>   <div style='display: none;'></div>  <div>  <div class='_rp_r5 ms-font-weight-regular ms-font-color-neutralDark' role='presentation' tabindex='-1' id='Item.MessageNormalizedBody' 
            style='font-family: &quot;wf_segoe-ui_normal&quot;,&quot;Segoe UI&quot;,&quot;Segoe WP&quot;,Tahoma,Arial,sans-serif,serif,&quot;EmojiFont&quot;;'><div 
            class='rps_5e8f'> 
            <div>
            <div style='background-color:#ebebeb'>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table class='x_devicewidth' width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td>
            <table class='x_devicewidth2' style='margin:0 auto' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' 
            align='center'>
            <tbody style='line-height:12px'>
            <tr>
            <td style='' width='8' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            <tr>
            <td  width='100%'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr><td  align='center'>
            <span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;;font-weight:bold; font-size: 24px; color: rgb(64,106,153); line-height: 24px;'>TRANSTEC</span> <br/>
            <span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;; font-weight:bold; font-size: 12px; color: rgb(222, 66, 66); line-height: 14px;'>Translation & Localization</span> </td>
            <td align='right'><a  href='https://www.transteceg.com/en/' target='_blank' rel='noopener noreferrer' alt='name.com' style='line-height:14px; text-
            decoration:none'><img src='https://www.transteceg.com/images/logo.png' alt='TransTec' title='name.com' width='100'> </a></td>
            </tr> 
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td width='100%' bgcolor='#C81517'>
            <table  style='padding:0 10px 0 10px' width='580' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='22'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:22px; color:#ffffff; line-height:26px; padding:0 20px 0 20px' align='center'>
            <b>[TITLE]</b> </td>
            </tr>
            <tr>
            <td width='100%' height='16'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:13px; color:#666666; text-align:left; line-height:18px; padding:10px'>
            <table cellspacing='0' cellpadding='0' style='width:100%;'>
            <tbody>
            <tr>
            <td align='left' style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:20px 20px 0 20px; color:#333333'>
            <p style='margin:0px; text-align:left'>Dear <strong><label id='lblOffer_RECEPIENT_NAME'>Mr. [RECEPIENT.NAME]</label></strong></p>
            <br>
            </td>
            </tr>
            </tbody>
            </table>
            <table id='x_email_content' cellspacing='0' width='100%' cellpadding='0'>
            <tbody>
            <tr>
            <td style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:0 20px 0 20px; 
            color:#333333'>
            <p style='margin:20px 0 0 0'><label id='lblOffer_MESSAGE'>[MESSAGE]</label></p>
            </td>
            </tr>
            <tr>
            <td style='background-color:#FFFFFF; padding:40px 0 20px 0' align='center'>
            <a href='[BUTTON.HREF]' target='_blank'  
            rel='noopener noreferrer' style='font-family:Helvetica,sans-serif,Arial; color:#FFFFFF; font-weight:bold; text-transform:uppercase; letter-spacing:1px; font-size:13px;  
            text-decoration:none; padding:20px 40px; background-color:#2066b1; display:inline-block'>[BUTTON.TEXT]</a> 
            </td>
            </tr>
            <tr>
            <td style='background-color:#FFFFFF; padding:0 0 50px 0' align='center'><a href='[LINK.HREF]' 
                target='_blank' rel='noopener noreferrer' style='font-family:Helvetica,sans-serif,Arial; color:#8ac556; font-size:13px'>[LINK.TEXT]</a> </td>
            </tr>
            <tr>
            <td  class='x_mobile-padding' style='background-color:#FFFFFF; padding:0 20px 30px 20px' align='center'>
            <table id='x_domain-renewals-later' width='100%' cellspacing='0'  cellpadding='0'>
            <tbody>
            <tr>
            <td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>
            Service List </td>
            <td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='right'>
            Price </td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,sans-serif,Arial; font-size:18px; font-weight:bold; color:#333333; padding:10px 0 0 0' align='left'>
            Service1 </td>
            <td style='text-decoration:none; color:#333334; font-family:Helvetica,sans-serif,Arial; font-size:18px; font-weight:bold; color:#999999; padding:10px 0 0 0' align='right'>
            $12.99 </td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,sans-serif,Arial; font-size:13px; color:#4D4E53; padding:5px 0 0 0'>
            IssueDate: September 04 </td>
            <td>&nbsp;</td>
            </tr>            
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:24px; font-weight:bold; color:#333333; padding:0 0 5px 0' align='center'>
            Total: $12.99 </td>
            </tr>
            <tr>
            <td style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:13px; color:#ff0000' align='center'>
            Amount due to be billed : $12.99 </td>
            </tr>
            <tr>
            <td style='background-color:#FFFFFF; padding:20px 0 40px 0' align='center'>
            <table cellspacing='0' cellpadding='0'>
            <tbody>
            <tr>
            <td><a href='[BUTTON2.URL]' target='_blank' rel='noopener noreferrer' style='font-family:Helvetica,sans-serif,Arial; color:#FFFFFF; font-weight:bold; text-transform:uppercase; letter-spacing:1px; font-size:13px; text-decoration:none; padding:20px 40px; background-color:#2066b1; display:inline-block'>[BUTTON2.TEXT]</a> </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='border-top:1px solid #ececec' height='12' bgcolor='#f7f7f7'></td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table id='x_backgroundTable' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table  class='x_devicewidth2' style='margin:0 auto' width='596' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' align='center'>
            <tbody>
            <tr>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#f7f7f7' align='center'>
            <tbody> 
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' style='display:inline-block' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody> 
            <tr>
            <td align='center'>
            <table style='display:inline-block' cellspacing='0' cellpadding='0' border='0'>
            <tbody style='display:inline-block' align='center'>
 
            <tr align='left'>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; color:#9f9f9f; line-height:20px'>
            <b>Office</b>
             703, 1 Hafez Ramadan, From Makram Ebied, Opposite to City Center Mall, Nasr City, Cairo, Egypt.
            <br/>
            <b>Support:</b> <a href='mailto:info@transteceg.com' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>info@transteceg.com</a>   <b> or </b>
            <a href='tel:00201007502179 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 1007502179  </a> <b> or </b>
              <a href='tel:0020222720160 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 222720160</a></td>
            </tr>
            <tr>
            <td 
            width='100%' height='5'></td>
            </tr>
            </tbody>
            </table>
            <table style='display:inline-block; text-align:center' width='200' cellspacing='0' cellpadding='0' border='0'>
            <tbody 

            style='display:inline-block' align='center'>

            <tr>
            <td valign='middle'><a href='https://www.facebook.com/transtecegypt' target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Facebook'><img  
            src='https://d1hoh05jeo8jse.cloudfront.net/media/email/facebook.jpg' alt='Facebook' width='30' height='30'> </a></td>
            <td valign='middle'><a 

            href='https://www.twitter.com/transtecegypt' target='_blank' rel='noopener noreferrer' 

            class='x_image_fix' alt='Twitter' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/twitter.jpg' alt='Twitter' width='30' 

            height='30'> </a></td>
            <td valign='middle'><a href='https://plus.google.com/+Transtecegypt' 

            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Youtube' style='margin-left:10px'><img 

            src='http://mariposafire.com/wp-content/plugins/gplus-comments/assets/images/icons/default/gplus.png' alt='YouTube' width='30' height='30'> </a></td>
            <td valign='middle'><a 

            href='https://transtecegypt.blogspot.com.eg/' 

            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Blog' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/blog.jpg' 

            alt='Our Blog' width='30' height='30'> </a></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' 
            height='25'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; line-height:15px; color:#afafaf' valign='middle' align='center'>© 2001-2017 All Rights Reserved. LinkMasr.com is a registered trademark of <a href='http://www.LinkMasr.com' 
            target='_blank' rel='noopener noreferrer' style='color:#afafaf'>LinkMasr.com</a> Inc.<br>
            </td>
            </tr>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </div>
            <img src='https://www.name.com/services/email_product/email_track?id=8761061&amp;key=40b19b51c927f03b7d2f2de7b92d4c6f' 
            style='overflow:hidden' width='1' height='1'>  </div> </div>
            </div></div> <div style='display: none;'></div> </div> </div></div> <div style='display: none;'></div>  ";
        #endregion

        #region Template1_Short 
        public static string Template1_Short = @"
                         <div><div autoid='_rp_F' class='_rp_q5 rpHighlightAllClass rpHighlightBodyClass allowTextSelection' role='region' aria-label='Message body'>   <div style='display: none;'></div>  <div>  <div class='_rp_r5 ms-font-weight-regular ms-font-color-neutralDark' role='presentation' tabindex='-1' id='Item.MessageNormalizedBody' 
            style='font-family: &quot;wf_segoe-ui_normal&quot;,&quot;Segoe UI&quot;,&quot;Segoe WP&quot;,Tahoma,Arial,sans-serif,serif,&quot;EmojiFont&quot;;'><div 
            class='rps_5e8f'> 
            <div>
            <div style='background-color:#ebebeb'>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table class='x_devicewidth' width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td>
            <table class='x_devicewidth2' style='margin:0 auto' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' 
            align='center'>
            <tbody style='line-height:12px'>
            <tr>
            <td style='' width='8' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            <tr>
            <td  width='100%'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr><td  align='center'>
            <span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;;font-weight:bold; font-size: 24px; color: rgb(64,106,153); line-height: 24px;'>TRANSTEC</span> <br/>
            <span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;; font-weight:bold; font-size: 12px; color: rgb(222, 66, 66); line-height: 14px;'>Translation & Localization</span> </td>
            <td align='right'><a  href='https://www.transteceg.com/en/' target='_blank' rel='noopener noreferrer' alt='name.com' style='line-height:14px; text-
            decoration:none'><img src='https://www.transteceg.com/images/logo.png' alt='TransTec' title='name.com' width='100'> </a></td>
            </tr> 
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td width='100%' bgcolor='#C81517'>
            <table  style='padding:0 10px 0 10px' width='580' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='22'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:22px; color:#ffffff; line-height:26px; padding:0 20px 0 20px' align='center'>
            <b>[TITLE]</b> </td>
            </tr>
            <tr>
            <td width='100%' height='16'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:13px; color:#666666; text-align:left; line-height:18px; padding:10px'>
            <table cellspacing='0' cellpadding='0' style='width:100%;'>
            <tbody>
            <tr>
            <td align='left' style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:20px 20px 0 20px; color:#333333'>
            <p style='margin:0px; text-align:left'>Dear <strong><label id='lblOffer_RECEPIENT_NAME'>Mr. [RECEPIENT.NAME]</label></strong></p>
            <br>
            </td>
            </tr>
            </tbody>
            </table>
            <table id='x_email_content' cellspacing='0' width='100%' cellpadding='0'>
            <tbody>
            <tr>
            <td style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:0 20px 0 20px; 
            color:#333333'>
            <p style='margin:20px 0 0 0'><label id='lblOffer_MESSAGE'>[MESSAGE]</label></p>
            </td>
            </tr>  
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='border-top:1px solid #ececec' height='12' bgcolor='#f7f7f7'></td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table id='x_backgroundTable' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table  class='x_devicewidth2' style='margin:0 auto' width='596' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' align='center'>
            <tbody>
            <tr>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#f7f7f7' align='center'>
            <tbody> 
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' style='display:inline-block' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody> 
            <tr>
            <td align='center'>
            <table style='display:inline-block' cellspacing='0' cellpadding='0' border='0'>
            <tbody style='display:inline-block' align='center'>
 
            <tr align='left'>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; color:#9f9f9f; line-height:20px'>
            <b>Office</b>
             703, 1 Hafez Ramadan, From Makram Ebied, Opposite to City Center Mall, Nasr City, Cairo, Egypt.
            <br/>
            <b>Support:</b> <a href='mailto:info@transteceg.com' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>info@transteceg.com</a>   <b> or </b>
            <a href='tel:00201007502179 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 1007502179  </a> <b> or </b>
              <a href='tel:0020222720160 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 222720160</a></td>
            </tr>
            <tr>
            <td 
            width='100%' height='5'></td>
            </tr>
            </tbody>
            </table>
            <table style='display:inline-block; text-align:center' width='200' cellspacing='0' cellpadding='0' border='0'>
            <tbody 

            style='display:inline-block' align='center'>

            <tr>
            <td valign='middle'><a href='https://www.facebook.com/transtecegypt' target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Facebook'><img  
            src='https://d1hoh05jeo8jse.cloudfront.net/media/email/facebook.jpg' alt='Facebook' width='30' height='30'> </a></td>
            <td valign='middle'><a 

            href='https://www.twitter.com/transtecegypt' target='_blank' rel='noopener noreferrer' 

            class='x_image_fix' alt='Twitter' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/twitter.jpg' alt='Twitter' width='30' 

            height='30'> </a></td>
            <td valign='middle'><a href='https://plus.google.com/+Transtecegypt' 

            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Youtube' style='margin-left:10px'><img 

            src='http://mariposafire.com/wp-content/plugins/gplus-comments/assets/images/icons/default/gplus.png' alt='YouTube' width='30' height='30'> </a></td>
            <td valign='middle'><a 

            href='https://transtecegypt.blogspot.com.eg/' 

            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Blog' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/blog.jpg' 

            alt='Our Blog' width='30' height='30'> </a></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' 
            height='25'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; line-height:15px; color:#afafaf' valign='middle' align='center'>© 2001-2017 All Rights Reserved. LinkMasr.com is a registered trademark of <a href='http://www.LinkMasr.com' 
            target='_blank' rel='noopener noreferrer' style='color:#afafaf'>LinkMasr.com</a> Inc.<br>
            </td>
            </tr>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </div>
            <img src='https://www.name.com/services/email_product/email_track?id=8761061&amp;key=40b19b51c927f03b7d2f2de7b92d4c6f' 
            style='overflow:hidden' width='1' height='1'>  </div> </div>
            </div></div> <div style='display: none;'></div> </div> </div></div> <div style='display: none;'></div>
			 ";
        #endregion

        #region Template_Quotation
        public static string Template_Quotation = @"
                         <div><div autoid='_rp_F' class='_rp_q5 rpHighlightAllClass rpHighlightBodyClass allowTextSelection' role='region' aria-label='Message body'>   <div style='display: none;'></div>  <div>  <div class='_rp_r5 ms-font-weight-regular ms-font-color-neutralDark' role='presentation' tabindex='-1' id='Item.MessageNormalizedBody' 
            style='font-family: &quot;wf_segoe-ui_normal&quot;,&quot;Segoe UI&quot;,&quot;Segoe WP&quot;,Tahoma,Arial,sans-serif,serif,&quot;EmojiFont&quot;;'><div 
            class='rps_5e8f'> 
            <div>
            <div style='background-color:#ebebeb'>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table class='x_devicewidth' width='100%' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table width='100%' cellspacing='0' cellpadding='0' 
            border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td>
            <table class='x_devicewidth2' style='margin:0 auto' width='596' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' 
            align='center'>
            <tbody style='line-height:12px'>
            <tr>
            <td style='' width='8' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#ffffff' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            <tr>
            <td  width='100%'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td align='left'><a  href='https://www.transteceg.com/en/' target='_blank' rel='noopener noreferrer' alt='name.com' style='line-height:14px; text-
            decoration:none'><img src='http://www.transsmart.org/logos/logo.png' alt='TransTec' width='140'> </a></td>
            <td  align='center'><span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;;font-weight:bold; font-size: 24px; color: rgb(64,106,153); line-height: 24px;'>TRANSTEC</span> <br/>
            <span style='font-family: Helvetica,arial,sans-serif,serif,&quot;EmojiFont&quot;; font-weight:bold; font-size: 12px; color: rgb(222, 66, 66); line-height: 14px;'>Translation & Localization</span> </td>
            <td align='right'><a  href='https://www.transteceg.com/en/' target='_blank' rel='noopener noreferrer' alt='name.com' style='line-height:14px; text-
            decoration:none'><img src='http://www.transsmart.org/logos/tuv.png' alt='TransTec' width='50'> 
            <img src='http://www.transsmart.org/logos/lics.png' alt='TransTec' width='100'> </a></td>
            </tr> 
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td width='100%' bgcolor='#C81517'>
            <table  style='padding:0 10px 0 10px' width='580' cellspacing='0' cellpadding='0' border='0' align='center'>
            <tbody>
            <tr>
            <td width='100%' height='22'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:22px; color:#ffffff; line-height:26px; padding:0 20px 0 20px' align='center'>
            <b>[TITLE]</b> </td>
            </tr>
            <tr>
            <td width='100%' height='16'></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:13px; color:#666666; text-align:left; line-height:18px; padding:10px'>
            <table cellspacing='0' cellpadding='0' style='width:100%;'>
            <tbody>
            <tr>
            <td align='left' style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:10px 10px 0 10px; color:#333333'>
            <p style='margin:0px; text-align:left'>Dear <strong><label id='lblOffer_RECEPIENT_NAME'>Mr. [RECEPIENT.NAME]</label></strong></p>
            <br>
			In refrence to your RFP, kindly find below our estimation for the amount and the deadline of the requested services.
			<br>
			<table width='100%' cellpadding='0'>
            <tbody>
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'></td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'></td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Activity</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Translation</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Quotation Date</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[QUOTATION.DATE]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Quotation No.</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[QUOTATION.NO]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Language</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[LANGUAGE]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Word count</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[WORD.COUNT]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Word rate</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[PAGE.RATE]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Discount</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[DISCOUNT]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>VAT</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[VAT]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Total price</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[TOTAL.PRICE]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Delivery</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px;  border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[DELIVERY]</td> 
            </tr>  
            <tr>
			<td style='font-family:Helvetica,sans-serif,Arial; color:#333333; font-size:14px; text-transform:uppercase; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>Payment method</td> 
			<td style='font-family:Helvetica,sans-serif,Arial; color:#999999; font-size:14px; border-bottom:1px solid #999999; padding:0 0 5px 0' align='left'>[PAYMENT.METHOD]</td> 
            </tr>  
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table id='x_email_content' cellspacing='0' width='100%' cellpadding='0'>
            <tbody>
            <tr>
            <td style='background-color:#FFFFFF; font-family:Helvetica,sans-serif,Arial; font-size:18px; line-height:24px; padding:0 20px 0 20px; 
            color:#333333'>
            <p style='margin:20px 0 0 0'><b>Post Sale:</b><br/>
			we acknowledge to review/correct the translation upon your request/as necessary , as the case may be for 30 (thirty) working days from the date of delivery.
			</p>
			<p>
			<b>
			We hope that our offer meets your expectations,<br/>
			Best Regards,
			</b>
			</p>
            </td>
            </tr>  
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' height='20'></td>
            </tr>
            <tr>
            <td style='border-top:1px solid #ececec' height='12' bgcolor='#f7f7f7'></td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </div>
            <div class='x_block'>
            <table id='x_backgroundTable' width='100%' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb'>
            <tbody>
            <tr>
            <td width='100%'>
            <table  class='x_devicewidth2' style='margin:0 auto' width='596' cellspacing='0' cellpadding='0' border='0' bgcolor='#ebebeb' align='center'>
            <tbody>
            <tr>
            <td style='' width='8'  height='7' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-top-corner.png'>
            </td>
            <td style='' valign='top' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/top-shadow.png'>
            </td>
            <td style='' width='8' height='7'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-top-corner.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' valign='top'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-shadow.png'>
            </td>
            <td valign='top'>
            <table class='x_devicewidth' style='border:1px solid #d9d8d8' width='580' cellspacing='0' cellpadding='0' border='0' bgcolor='#f7f7f7' align='center'>
            <tbody> 
            <tr>
            <td style='text-align:center'>
            <table class='x_devicewidthinner' style='display:inline-block' width='550' cellspacing='0' cellpadding='10' border='0' align='center'>
            <tbody> 
            <tr>
            <td align='center'>
            <table style='display:inline-block' cellspacing='0' cellpadding='0' border='0'>
            <tbody style='display:inline-block' align='center'>
            <tr align='left'>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; color:#9f9f9f; line-height:20px'>
            <b>Office</b>
             703, 1 Hafez Ramadan, From Makram Ebied, Opposite to City Center Mall, Nasr City, Cairo, Egypt.
            <br/>
            <b>Support:</b> <a href='mailto:info@transteceg.com' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>info@transteceg.com</a>   <b> or </b>
            <a href='tel:00201007502179 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 1007502179  </a> <b> or </b>
              <a href='tel:0020222720160 ' target='_blank' rel='noopener noreferrer' style='color:#9f9f9f'>+20 222720160</a></td>
            </tr>
            <tr>
            <td 
            width='100%' height='5'></td>
            </tr>
            </tbody>
            </table>
            <table style='display:inline-block; text-align:center' width='200' cellspacing='0' cellpadding='0' border='0'>
            <tbody 
            style='display:inline-block' align='center'>
            <tr>
            <td valign='middle'><a href='https://www.facebook.com/transtecegypt' target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Facebook'><img  
            src='https://d1hoh05jeo8jse.cloudfront.net/media/email/facebook.jpg' alt='Facebook' width='30' height='30'> </a></td>
            <td valign='middle'><a 
            href='https://www.twitter.com/transtecegypt' target='_blank' rel='noopener noreferrer' 
            class='x_image_fix' alt='Twitter' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/twitter.jpg' alt='Twitter' width='30' 
            height='30'> </a></td>
            <td valign='middle'><a href='https://plus.google.com/+Transtecegypt' 
            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Youtube' style='margin-left:10px'><img 
            src='http://mariposafire.com/wp-content/plugins/gplus-comments/assets/images/icons/default/gplus.png' alt='YouTube' width='30' height='30'> </a></td>
            <td valign='middle'><a 
            href='https://transtecegypt.blogspot.com.eg/' 
            target='_blank' rel='noopener noreferrer' class='x_image_fix' alt='Blog' style='margin-left:10px'><img src='https://d1hoh05jeo8jse.cloudfront.net/media/email/blog.jpg' 
            alt='Our Blog' width='30' height='30'> </a></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            <td style='' width='8' valign='top' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-shadow.png'>
            </td>
            </tr>
            <tr>
            <td style='' width='8' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/left-bottom-corner.png'>
            </td>
            <td style='' valign='top' height='13' background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/bottom-shadow.png'>
            </td>
            <td style='' width='8' height='13'  background='https://d1hoh05jeo8jse.cloudfront.net/media/email/shadows/right-bottom-corner.png'>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width='100%' 
            height='25'></td>
            </tr>
            <tr>
            <td style='font-family:Helvetica,arial,sans-serif; font-size:10px; line-height:15px; color:#afafaf' valign='middle' align='center'>© 2001-2017 All Rights Reserved. LinkMasr.com is a registered trademark of <a href='http://www.LinkMasr.com' 
            target='_blank' rel='noopener noreferrer' style='color:#afafaf'>LinkMasr.com</a> Inc.<br>
            </td>
            </tr>
            <tr>
            <td width='100%' height='25'></td>
            </tr>
            </tbody>
            </table>
            </div>
            <img src='https://www.name.com/services/email_product/email_track?id=8761061&amp;key=40b19b51c927f03b7d2f2de7b92d4c6f' 
            style='overflow:hidden' width='1' height='1'>  </div> </div>
            </div></div> <div style='display: none;'></div> </div> </div></div> <div style='display: none;'></div>			
            ";
        #endregion

    }
}