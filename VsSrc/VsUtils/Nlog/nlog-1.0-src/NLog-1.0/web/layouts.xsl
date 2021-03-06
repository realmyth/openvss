<?xml version="1.0" encoding="windows-1250" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:include href="style.xsl" />

    <xsl:param name="l_name" />

    <xsl:template match="*" mode="content">
        <xsl:if test="not($l_name)">
            <h1>Layouts</h1>
            <p>
                The following layouts are available.
            </p>
            <div class="noborder">
                <table class="listtable">
                    <xsl:call-template name="supportmatrixheader" />
                    <xsl:apply-templates select="//class[attribute/@name='NLog.LayoutAttribute']" mode="list">
                        <xsl:sort select="../../@name" />
                        <xsl:sort select="attribute[@name='NLog.LayoutAttribute']/property[@name='Name']/@value" />
                    </xsl:apply-templates>
                </table>
            </div>
        </xsl:if>
        <xsl:if test="$l_name">
            <xsl:apply-templates select="//class[attribute/@name='NLog.LayoutAttribute' and attribute/property[@name='Name']/@value=$l_name]" mode="details">
                <xsl:sort select="../../@name" />
                <xsl:sort select="attribute[@name='NLog.LayoutAttribute']/property[@name='Name']/@value" />
            </xsl:apply-templates>
        </xsl:if>
    </xsl:template>

    <xsl:template match="class" mode="list">
        <xsl:variable name="type_tag" select="attribute[@name='NLog.LayoutAttribute']/property[@name='Name']/@value" />
        <tr>
            <td class="name"><a href="layout.{$type_tag}.html"><xsl:value-of select="$type_tag" /></a></td>
            <td class="description"><xsl:apply-templates select="documentation/summary" /></td>
            <xsl:call-template name="supportmatrixvalues" />
        </tr>
    </xsl:template>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()" />
        </xsl:copy>
    </xsl:template>

    <xsl:template match="summary">
        <xsl:apply-templates />
    </xsl:template>

    <xsl:template match="class" mode="details">
        <xsl:variable name="type_tag" select="attribute[@name='NLog.LayoutAttribute']/property[@name='Name']/@value" />
        <xsl:variable name="ignoresPadding" select="attribute[@name='NLog.LayoutAttribute']/property[@name='IgnoresPadding']/@value" />
        <h3>${<xsl:value-of select="$type_tag" />} Layout Renderer</h3>
        <hr size="1" />
        <xsl:apply-templates select="documentation/summary" /><p/>
        <xsl:call-template name="detailssupportmatrix" />
        <xsl:if test="property[not(@declaringType='NLog.Layout')] or not($ignoresPadding='True')">
            <h4>Parameters:</h4>
            <table class="paramtable">
                <tr>
                    <th>Name</th>
                    <th>Type</th>
                    <th>Description</th>
                </tr>
                <xsl:apply-templates select="property" mode="parameter">
                    <xsl:sort select="count(attribute[@name='NLog.Config.RequiredParameterAttribute'])" order="descending" />
                    <xsl:sort select="@name" />
                </xsl:apply-templates>
            </table>
        </xsl:if>
        <xsl:if test="documentation/remarks">
            <h4>Remarks:</h4>
            <xsl:apply-templates select="documentation/remarks" />
        </xsl:if>
        <xsl:if test="documentation/example">
            <h4>Example:</h4>
            <xsl:apply-templates select="documentation/example" />
        </xsl:if>
        <hr size="1" />
        <a href="layouts.html">Back to the layout list.</a>
    </xsl:template>

    <xsl:template match="property[@set='false']" mode="parameter">
        <!-- ignore -->
    </xsl:template>

    <xsl:template match="property[@name='Name']" mode="parameter">
        <!-- ignore -->
    </xsl:template>

    <xsl:template match="property[@name='Type']" mode="parameter">
        <!-- ignore -->
    </xsl:template>

    <xsl:template match="property[@type='NLog.Layout']" mode="parameter">
        <!-- ignore -->
    </xsl:template>

    <xsl:template match="property[@type='NLog.ILayout']" mode="parameter">
        <!-- ignore -->
    </xsl:template>

    <xsl:template match="property" mode="parameter">
        <xsl:call-template name="parameter_info" />
    </xsl:template>

    <xsl:template match="property[attribute/@name='NLog.Config.ArrayParameterAttribute']" mode="parameter2">
        <xsl:variable name="itemtype" select="attribute[@name='NLog.Config.ArrayParameterAttribute']/property[@name='ElementType']/@value" />
        <br/>&lt;<xsl:value-of select="@name" />&gt;<br/>
        <xsl:value-of select="$itemtype" />
        <xsl:apply-templates select="//class[@name='$itemtype']" mode="parameter" />
        &lt;/<xsl:value-of select="@name" />&gt;
    </xsl:template>

    <xsl:template match="property" mode="parameter2">
    </xsl:template>

    <xsl:template match="c">
        <code><xsl:apply-templates /></code>
    </xsl:template>

    <xsl:template match="code">
        <code><pre class="example"><xsl:apply-templates /></pre></code>
    </xsl:template>

    <xsl:template match="see">
        <code><xsl:value-of select="@cref" /></code>
    </xsl:template>
</xsl:stylesheet>
